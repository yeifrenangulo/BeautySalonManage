using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Sales.Queries;

public class SaleDetailDto : IMapFrom<SaleDetail>
{
    public int CollaboratorId { get; set; }
    public string CollaboratorName { get; set; }
    public string CollaboratorSurname { get; set; }
    public int ServiceId { get; set; }
    public string ServiceTitle { get; set; }
    public decimal Price { get; set; }
}
