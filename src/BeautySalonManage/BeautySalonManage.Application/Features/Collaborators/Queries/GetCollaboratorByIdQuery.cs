using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Exceptions;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Collaborators.Queries
{
    public class GetCollaboratorByIdQuery : IRequest<Response<CollaboratorDTO>>
    {
        public int CollacoratorId { get; set; }
    }

    public class GetCollaboratorByIdQueryHandler : IRequestHandler<GetCollaboratorByIdQuery, Response<CollaboratorDTO>>
    {
        private readonly IRepositoryAsync<Collaborator> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetCollaboratorByIdQueryHandler(IRepositoryAsync<Collaborator> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<CollaboratorDTO>> Handle(GetCollaboratorByIdQuery request, CancellationToken cancellationToken)
        {
            Collaborator collaborator = await _repositoryAsync.FirstOrDefaultAsync(new CollaboratorSpecification(request.CollacoratorId), cancellationToken);

            if (collaborator == null)
                throw new KeyNotFoundException($"el colaborador con ID {request.CollacoratorId} no se encuentra registrado");

            CollaboratorDTO collaboratorDTO = _mapper.Map<CollaboratorDTO>(collaborator);
            return new Response<CollaboratorDTO>(collaboratorDTO);
        }
    }
}
