using BeautySalonManage.Application.Common.Models;

namespace BeautySalonManage.Application.Customers.Queries;

public class GetAllCustomersParameter : RequestParameter
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
