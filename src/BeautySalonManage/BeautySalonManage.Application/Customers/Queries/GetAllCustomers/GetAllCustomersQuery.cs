using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Customers.Queries.GetAllCustomers;

public class GetAllCustomersQuery : GetAllCustomersParameter, IRequest<PagedResponse<List<CustomerDto>>>
{
}