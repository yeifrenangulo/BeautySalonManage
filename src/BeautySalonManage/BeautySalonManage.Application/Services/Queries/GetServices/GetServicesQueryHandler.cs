using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Services.Queries.GetServices;

public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, PagedResponse<List<ServiceDto>>>
{
    private readonly IRepositoryAsync<Service> _repository;
    private readonly IMapper _mapper;

    public GetServicesQueryHandler(IRepositoryAsync<Service> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<List<ServiceDto>>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        int count = await _repository.CountAsync(cancellationToken);

        List<ServiceDto> services = (await _repository.ListAsync(new ServiceSpecification(request.PageNumber, request.PageSize), cancellationToken))
            .ProjectToList<Service, ServiceDto>(_mapper.ConfigurationProvider);

        return new PagedResponse<List<ServiceDto>>(services, request.PageNumber, request.PageSize, count);
    }
}