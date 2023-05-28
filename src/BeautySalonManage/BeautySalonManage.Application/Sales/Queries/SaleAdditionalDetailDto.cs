using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Sales.Queries;

public class SaleAdditionalDetailDto : IMapFrom<SaleAdditionalDetail>
{
    public int CollaboratorId { get; set; }
    public string CollaboratorName { get; set; }
    public string CollaboratorSurname { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }
}