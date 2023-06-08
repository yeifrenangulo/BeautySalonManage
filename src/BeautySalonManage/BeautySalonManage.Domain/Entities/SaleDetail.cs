using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class SaleDetail : BaseEntity
{
    public Guid SaleId { get; set; }
    public int CollaboratorId { get; set; }
    public int ServiceId { get; set; }
    public decimal Price { get; set; }

    public virtual Sale Sale { get; set; }
    public virtual Service Service { get; set; }
    public virtual Collaborator Collaborator { get; set; }
}
