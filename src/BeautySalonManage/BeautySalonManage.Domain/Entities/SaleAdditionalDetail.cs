using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class SaleAdditionalDetail : BaseEntity
{
    public Guid Id { get; set; }
    public Guid SaleId { get; set; }
    public int CollaboratorId { get; set; }
    public string Detail { get; set; }
    public decimal Price { get; set; }

    public virtual Sale Sale { get; set; }
    public virtual Collaborator Collaborator { get; set; }
}
