using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Customers.Commands.Delete.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
}