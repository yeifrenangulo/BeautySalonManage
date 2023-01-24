using Ardalis.Specification;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Specifications
{
    public class TurnSpecification : Specification<Turn>
    {
        public TurnSpecification(DateTime startDate, DateTime endDate) 
        {
            Query.Where(x => x.IsActive && x.StartDate >= startDate && x.StartDate <= endDate)
                 .Include(x => x.TurnDetails)
                 .Include("TurnDetails.Collaborator")
                 .Include("TurnDetails.Service")
                 .OrderBy(x => x.StartDate);
        }
    }
}
