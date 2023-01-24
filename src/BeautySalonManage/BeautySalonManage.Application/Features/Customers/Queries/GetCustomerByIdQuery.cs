using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<Response<CustomerDTO>>
    {
        public int CustomerId { get; set; }
    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<CustomerDTO>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<CustomerDTO>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            Customer customer = await _repositoryAsync.FirstOrDefaultAsync(new CustomerSpecification(request.CustomerId), cancellationToken);

            if (customer is null)
                throw new KeyNotFoundException($"El cliente con ID {request.CustomerId} no se encuentra registrado.");

            CustomerDTO dto = _mapper.Map<CustomerDTO>(customer);

            return new Response<CustomerDTO>(dto);
        }
    }
}
