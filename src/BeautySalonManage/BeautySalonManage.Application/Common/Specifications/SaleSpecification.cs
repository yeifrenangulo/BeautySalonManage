using Ardalis.Specification;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Common.Specifications;

public class SaleSpecification : Specification<Sale>
{
    public SaleSpecification(RequestParameter parameter)
    {
        Query.Include(x => x.SaleDetails)
             .Include(x => x.SaleAdditionalDetails)
             .Include("SaleDetails.Collaborator")
             .Include("SaleDetails.Service")
             .Include("SaleAdditionalDetails.Collaborator")
             .Where(x => x.IsActive)
             .OrderBy(x => x.Id)
             .Skip((parameter.PageNumber - 1) * parameter.PageSize)
             .Take(parameter.PageSize);
    }

    public SaleSpecification(Guid id)
    {
        Query.Include(x => x.SaleDetails)
             .Include(x => x.SaleAdditionalDetails)
             .Include("SaleDetails.Collaborator")
             .Include("SaleDetails.Service")
             .Include("SaleAdditionalDetails.Collaborator")
             .Where(x => x.IsActive && x.Id == id);
    }
}
