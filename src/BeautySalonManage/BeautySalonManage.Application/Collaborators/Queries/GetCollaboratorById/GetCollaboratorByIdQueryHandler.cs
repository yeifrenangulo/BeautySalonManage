using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Queries.GetCollaboratorById;

public class GetCollaboratorByIdQueryHandler : IRequestHandler<GetCollaboratorByIdQuery, Response<CollaboratorServiceDto>>
{
    private readonly IRepositoryAsync<Collaborator> _repository;
    private readonly IMapper _mapper;

    public GetCollaboratorByIdQueryHandler(IRepositoryAsync<Collaborator> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<CollaboratorServiceDto>> Handle(GetCollaboratorByIdQuery request, CancellationToken cancellationToken)
    {
        Collaborator collaborator = await _repository.FirstOrDefaultAsync(new CollaboratorSpecification(request.CollacoratorId), cancellationToken)
            ?? throw new KeyNotFoundException($"el colaborador con ID {request.CollacoratorId} no se encuentra registrado");

        CollaboratorServiceDto collaboratorDTO = _mapper.Map<CollaboratorServiceDto>(collaborator);
        return new Response<CollaboratorServiceDto>(collaboratorDTO);
    }
}
