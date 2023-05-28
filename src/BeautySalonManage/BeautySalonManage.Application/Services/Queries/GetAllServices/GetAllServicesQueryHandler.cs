using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Services.Queries.GetAllServices;

public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, Response<List<ServiceCollaboratorDto>>>
{
    private readonly IRepositoryAsync<Service> _repository;
    private readonly IMapper _mapper;

    public GetAllServicesQueryHandler(IRepositoryAsync<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<List<ServiceCollaboratorDto>>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
    {
        List<ServiceCollaboratorDto> services = (await _repository.ListAsync(new ServiceSpecification(), cancellationToken))
            .ProjectToList<Service, ServiceCollaboratorDto>(_mapper.ConfigurationProvider);

        return new Response<List<ServiceCollaboratorDto>>(services);
    }
}