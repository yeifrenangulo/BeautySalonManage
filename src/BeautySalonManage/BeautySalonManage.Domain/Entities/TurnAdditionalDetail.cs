using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class TurnAdditionalDetail : BaseEntity
{
    public long Id { get; set; }
    public long TurnId { get; set; }
    public int CollaboratorId { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }

    public virtual Turn Turn { get; set; }
    public virtual Collaborator Collaborator { get; set; }
}
