using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Collaborators.Queries
{
    public class GetAllCollaboratorsQuery : IRequest<PagedResponse<List<CollaboratorDTO>>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllCollaboratorsQueryHandler : IRequestHandler<GetAllCollaboratorsQuery, PagedResponse<List<CollaboratorDTO>>>
    {
        private readonly IRepositoryAsync<Collaborator> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCollaboratorsQueryHandler(IRepositoryAsync<Collaborator> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<CollaboratorDTO>>> Handle(GetAllCollaboratorsQuery request, CancellationToken cancellationToken)
        {
            int count = await _repositoryAsync.CountAsync(cancellationToken);

            List<Collaborator> collaborators = await _repositoryAsync.ListAsync(
                new CollaboratorSpecification(request.Name, request.Surname, request.PageNumber, request.PageSize), cancellationToken);

            List<CollaboratorDTO> collaboratorsDTO = _mapper.Map<List<CollaboratorDTO>>(collaborators);
            return new PagedResponse<List<CollaboratorDTO>>(collaboratorsDTO, request.PageNumber, request.PageSize, count);
        }
    }
}
