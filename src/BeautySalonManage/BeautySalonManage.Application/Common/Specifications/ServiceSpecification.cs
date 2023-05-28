using Ardalis.Specification;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Common.Specifications;

public class ServiceSpecification : Specification<Service>
{
    public ServiceSpecification()
    {
        Query.Include(x => x.CollaboratorServices)
                .ThenInclude(x => x.Collaborator)
             .Where(x => x.IsActive)
             .OrderBy(x => x.Title);
    }

    public ServiceSpecification(int pageNumber, int pageSize)
    {
        Query.Where(x => x.IsActive)
             .OrderBy(x => x.Title)
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize);
    }

    public ServiceSpecification(int id)
    {
        Query.Where(x => x.Id == id && x.IsActive);
    }
}
