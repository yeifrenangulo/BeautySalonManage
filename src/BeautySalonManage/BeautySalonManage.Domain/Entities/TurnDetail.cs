using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class TurnDetail : BaseEntity
{
    public long TurnId { get; set; }
    public int CollaboratorId { get; set; }
    public int ServiceId { get; set; }
    public decimal Price { get; set; }

    public virtual Collaborator Collaborator { get; set; }
    public virtual Service Service { get; set; }
    public virtual Turn Turn { get; set; }
}
