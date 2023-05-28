using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Turns.Queries;

public class TurnAdditionalDetailDto : IMapFrom<TurnAdditionalDetail>
{
    public int CollaboratorId { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }
}
