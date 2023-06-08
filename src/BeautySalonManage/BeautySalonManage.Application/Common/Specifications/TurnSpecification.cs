using Ardalis.Specification;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Common.Specifications
{
    public class TurnSpecification : Specification<Turn>
    {
        public TurnSpecification(DateTime startDate, DateTime endDate)
        {
            Query.Where(x => x.IsActive && x.StartDate >= startDate && x.StartDate <= endDate)
                 .Include(x => x.States)
                 .Include(x => x.TurnDetails)
                 .Include(x => x.TurnAdditionalDetails)
                 .Include("TurnDetails.Collaborator")
                 .Include("TurnDetails.Service")
                 .OrderBy(x => x.StartDate);
        }

        public TurnSpecification(Guid id)
        {
            Query.Where(x => x.IsActive && x.Id == id)
                 .Include(x => x.States)
                 .Include(x => x.TurnDetails)
                 .Include(x => x.TurnAdditionalDetails)
                 .Include("TurnDetails.Collaborator")
                 .Include("TurnDetails.Service");
        }
    }
}
