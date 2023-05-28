using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Customers.Commands.Create.CreateCustomer;

public class CreateCustomerCommand : IRequest<Response<int>>, IMapFrom<Customer>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public DateTime? DateBirth { get; set; }
    public int GenderId { get; set; }
}