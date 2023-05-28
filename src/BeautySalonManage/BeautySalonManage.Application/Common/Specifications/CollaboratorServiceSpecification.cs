using Ardalis.Specification;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Common.Specifications
{
    public class CollaboratorServiceSpecification : Specification<CollaboratorService>
    {
        public CollaboratorServiceSpecification(int collaboratorId)
        {
            Query.Where(x => x.CollaboratorId == collaboratorId);
        }
    }
}
