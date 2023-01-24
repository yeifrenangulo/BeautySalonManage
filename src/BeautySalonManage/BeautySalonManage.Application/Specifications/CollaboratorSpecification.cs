using Ardalis.Specification;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Specifications
{
    internal class CollaboratorSpecification : Specification<Collaborator>
    {
        public CollaboratorSpecification(string name, string surname)
        {
            Query.Where(w => w.Name == name && w.Surname == surname && w.IsActive);
        }

        public CollaboratorSpecification(string name, string surname, int pageNumber, int pageSize)
        {
            if (!string.IsNullOrEmpty(name))
                Query.Search(x => x.Name, $"%{name}%");

            if (!string.IsNullOrEmpty(surname))
                Query.Search(x => x.Surname, $"%{surname}%");

            Query.Include(x => x.Gender)
                 .Include(x => x.CollaboratorServices)
                    .ThenInclude(x => x.Service)
                 .Where(x => x.IsActive)
                 .OrderBy(x => x.CollaboratorId)
                 .Skip((pageNumber - 1) * pageSize)
                 .Take(pageSize);
        }

        public CollaboratorSpecification(int id)
        {
            Query.Where(x => x.CollaboratorId == id && x.IsActive)
                 .Include(x => x.Gender)
                 .Include(x => x.CollaboratorServices)
                    .ThenInclude(x => x.Service);
        }
    }
}
