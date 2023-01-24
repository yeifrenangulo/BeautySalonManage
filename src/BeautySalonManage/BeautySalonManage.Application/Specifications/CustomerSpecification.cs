using Ardalis.Specification;
using BeautySalonManage.Application.Features.Customers.Queries.Parameters;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Specifications
{
    public class CustomerSpecification : Specification<Customer>
    {
        public CustomerSpecification(GetAllCustomersParameter parameter)
        {
            if (!string.IsNullOrEmpty(parameter.Name))
                Query.Search(x => x.Name, $"%{parameter.Name}%");

            if (!string.IsNullOrEmpty(parameter.Surname))
                Query.Search(x => x.Surname, $"%{parameter.Surname}%");

            Query.Include(x => x.Gender)
                 .Where(x => x.IsActive)
                 .OrderBy(x => x.CustomerId)
                 .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                 .Take(parameter.PageSize);
        }

        public CustomerSpecification(string name, string surname)
        {
            Query.Where(w => w.Name == name && w.Surname == surname && w.IsActive);
        }

        public CustomerSpecification(int customerId)
        {
            Query.Where(w => w.CustomerId == customerId && w.IsActive)
                 .Include(x => x.Gender);
        }
    }
}
