using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Services.Queries;

public class ServicePercentageDto : IMapFrom<CollaboratorService>
{
    public int ServiceId { get; set; }
    public string ServiceTitle { get; set; }
    public decimal Percentage { get; set; }
}
