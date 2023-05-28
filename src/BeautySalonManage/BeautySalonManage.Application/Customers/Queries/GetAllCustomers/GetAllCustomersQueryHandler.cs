using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<List<CustomerDto>>>
{
    private readonly IRepositoryAsync<Customer> _repository;
    private readonly IMapper _mapper;

    public GetAllCustomersQueryHandler(IRepositoryAsync<Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResponse<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        int count = await _repository.CountAsync(cancellationToken);

        List<CustomerDto> customers = (await _repository.ListAsync(new CustomerSpecification(request), cancellationToken))
            .ProjectToList<Customer, CustomerDto>(_mapper.ConfigurationProvider);

        return new PagedResponse<List<CustomerDto>>(customers, request.PageNumber, request.PageSize, count);
    }
}

