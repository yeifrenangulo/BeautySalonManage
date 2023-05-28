using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Queries.GetAllCollaborators;

public class GetAllCollaboratorsQueryHandler : IRequestHandler<GetAllCollaboratorsQuery, PagedResponse<List<CollaboratorServiceDto>>>
{
    private readonly IRepositoryAsync<Collaborator> _repository;
    private readonly IMapper _mapper;

    public GetAllCollaboratorsQueryHandler(IRepositoryAsync<Collaborator> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<List<CollaboratorServiceDto>>> Handle(GetAllCollaboratorsQuery request, CancellationToken cancellationToken)
    {
        int count = await _repository.CountAsync(cancellationToken);

        List<CollaboratorServiceDto> collaborators = (await _repository.ListAsync(new CollaboratorSpecification(request.Name, request.Surname, request.PageNumber, request.PageSize), cancellationToken))
            .ProjectToList<Collaborator, CollaboratorServiceDto>(_mapper.ConfigurationProvider);

        return new PagedResponse<List<CollaboratorServiceDto>>(collaborators, request.PageNumber, request.PageSize, count);
    }
}
