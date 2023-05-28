using AutoMapper;
using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Common.Specifications;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDto>>
{
    private readonly IRepositoryAsync<Customer> _repository;
    private readonly IMapper _mapper;

    public GetCustomerByIdQueryHandler(IRepositoryAsync<Customer> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Customer customer = await _repository.FirstOrDefaultAsync(new CustomerSpecification(request.CustomerId), cancellationToken)
            ?? throw new KeyNotFoundException($"El cliente con ID {request.CustomerId} no se encuentra registrado.");

        CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);

        return new Response<CustomerDto>(customerDto);
    }
}