using BeautySalonManage.Application.Parameters;

namespace BeautySalonManage.Application.Features.Customers.Queries.Parameters
{
    public class GetAllCustomersParameter : RequestParameter
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
