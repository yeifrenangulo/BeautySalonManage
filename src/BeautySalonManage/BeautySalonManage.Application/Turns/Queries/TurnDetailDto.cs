using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Turns.Queries;

public class TurnDetailDto : IMapFrom<TurnDetail>
{
    public int CollaboratorId { get; set; }
    public string CollaboratorName { get; set; }
    public string CollaboratorSurname { get; set; }
    public int ServiceId { get; set; }
    public string ServiceTitle { get; set; }
    public string ServiceColor { get; set; }
    public string ServiceDuration { get; set; }
    public decimal Price { get; set; }
}
