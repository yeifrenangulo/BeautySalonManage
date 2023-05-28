using Ardalis.Specification;
using BeautySalonManage.Application.Customers.Queries;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Common.Specifications
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
                 .OrderBy(x => x.Name)
                 .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                 .Take(parameter.PageSize);
        }

        public CustomerSpecification(int customerId)
        {
            Query.Where(w => w.Id == customerId && w.IsActive)
                 .Include(x => x.Gender);
        }
    }
}
