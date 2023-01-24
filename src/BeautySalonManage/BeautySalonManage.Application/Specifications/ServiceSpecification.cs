using Ardalis.Specification;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Specifications
{
    public class ServiceSpecification : Specification<Service>
    {
        public ServiceSpecification(int pageNumber, int pageSize)
        {
            Query.Where(x => x.IsActive)
                 .OrderBy(x => x.ServiceId)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize);
        }

        public ServiceSpecification(int id)
        {
            Query.Where(x => x.ServiceId == id && x.IsActive);
        }
    }
}
