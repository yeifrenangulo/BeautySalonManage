using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQuery : IRequest<Response<CustomerDto>>
{
    public int CustomerId { get; set; }
}