using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Customers.Queries;

public class CustomerDto : IMapFrom<Customer>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public DateTime? DateBirth { get; set; }
    public int GenderId { get; set; }
    public string GenderName { get; set; }
}
