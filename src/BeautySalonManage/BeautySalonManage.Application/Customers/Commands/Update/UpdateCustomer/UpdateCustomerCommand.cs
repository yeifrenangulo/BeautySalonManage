using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Customers.Commands.Update.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public DateTime? DateBirth { get; set; }
    public int GenderId { get; set; }
}