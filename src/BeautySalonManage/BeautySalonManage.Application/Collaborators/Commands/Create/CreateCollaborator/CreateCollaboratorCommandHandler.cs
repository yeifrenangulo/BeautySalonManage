using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Exceptions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Commands.Create.CreateCollaborator;

public class CreateCollaboratorCommandHandler : IRequestHandler<CreateCollaboratorCommand, Response<int>>
{
    private readonly IRepositoryAsync<Collaborator> _repository;
    private readonly IRepositoryAsync<CollaboratorService> _repositoryCollaboratorService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCollaboratorCommandHandler(
        IRepositoryAsync<Collaborator> repository,
        IRepositoryAsync<CollaboratorService> repositoryCollaboratorService,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _repositoryCollaboratorService = repositoryCollaboratorService;
        _repository = repository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<int>> Handle(CreateCollaboratorCommand request, CancellationToken cancellationToken)
    {
        Collaborator collaborator = await _repository.FirstOrDefaultAsync(x => x.Name == request.Name && x.Surname == request.Surname, cancellationToken);

        if (collaborator != null)
        {
            throw new ApiException($"El colaborador {request.Name} {request.Surname} ya se encuentra registrado.");
        }

        Collaborator entity = _mapper.Map<Collaborator>(request);

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            await _repository.AddAsync(entity, cancellationToken);

            if (request.Services.Any())
            {
                List<CollaboratorService> collaboratorServices = new();

                foreach (var service in request.Services)
                {
                    collaboratorServices.Add(new CollaboratorService
                    {
                        CollaboratorId = entity.Id,
                        ServiceId = service.ServiceId,
                        Percentage = service.Percentage
                    });
                }

                await _repositoryCollaboratorService.AddRangeAsync(collaboratorServices, cancellationToken);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new Response<int>(entity.Id, "El colaborador se registro exitosamente");
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}
