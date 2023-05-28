using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Commands.Update.UpdateCollaborator;

public class UpdateCollaboratorCommandHandler : IRequestHandler<UpdateCollaboratorCommand, Response<int>>
{
    private readonly IRepositoryAsync<Collaborator> _repository;
    private readonly IRepositoryAsync<CollaboratorService> _repositoryCollaboratorService;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCollaboratorCommandHandler(
        IRepositoryAsync<Collaborator> repository,
        IRepositoryAsync<CollaboratorService> repositoryCollaboratorService,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _repositoryCollaboratorService = repositoryCollaboratorService;
    }

    public async Task<Response<int>> Handle(UpdateCollaboratorCommand request, CancellationToken cancellationToken)
    {
        Collaborator collaborator = await _repository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"El colaborador con ID {request.Id} no se encuentra registrado");

        await _unitOfWork.BeginTransactionAsync(cancellationToken);

        try
        {
            collaborator.Phone = request.Phone;
            collaborator.Address = request.Address;
            collaborator.Email = request.Email;
            collaborator.NameContact = request.NameContact;
            collaborator.PhoneContact = request.PhoneContact;
            collaborator.GenderId = request.GenderId;

            await _repository.UpdateAsync(collaborator, cancellationToken);

            List<CollaboratorService> _collaboratorServices =
                await _repositoryCollaboratorService.ListAsync(x => x.CollaboratorId == request.Id, cancellationToken);

            await _repositoryCollaboratorService.DeleteRangeAsync(_collaboratorServices, cancellationToken);

            if (request.Services.Any())
            {
                List<CollaboratorService> collaboratorServices = new();

                foreach (var service in request.Services)
                {
                    collaboratorServices.Add(new CollaboratorService
                    {
                        CollaboratorId = request.Id,
                        ServiceId = service.ServiceId,
                        Percentage = service.Percentage
                    });
                }

                await _repositoryCollaboratorService.AddRangeAsync(collaboratorServices, cancellationToken);
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new Response<int>(request.Id);
        }
        catch (Exception)
        {
            await _unitOfWork.RollbackAsync(cancellationToken);
            throw;
        }
    }
}