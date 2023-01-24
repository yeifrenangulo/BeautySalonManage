using AutoMapper;
using BeautySalonManage.Application.DTOs;
using BeautySalonManage.Application.Features.Customers.Queries.Parameters;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Application.Specifications;
using BeautySalonManage.Application.Wrappers;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Features.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<PagedResponse<List<CustomerDTO>>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PagedResponse<List<CustomerDTO>>>
    {
        private readonly IRepositoryAsync<Customer> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(IRepositoryAsync<Customer> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<CustomerDTO>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            int count = await _repositoryAsync.CountAsync(cancellationToken);
            //int pageTotal = count.GetNumberPageTotal(request.PageSize);

            List<Customer> customers = await _repositoryAsync.ListAsync(new CustomerSpecification(
                new GetAllCustomersParameter()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                }), cancellationToken);

            List<CustomerDTO> customersDTO = _mapper.Map<List<CustomerDTO>>(customers);
            return new PagedResponse<List<CustomerDTO>>(customersDTO, request.PageNumber, request.PageSize, count);
        }
    }
}
