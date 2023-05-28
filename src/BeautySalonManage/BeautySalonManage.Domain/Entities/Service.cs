using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class Service : BaseEntity
{
    public Service()
    {
        TurnDetails = new HashSet<TurnDetail>();
        SaleDetails = new HashSet<SaleDetail>();
        CollaboratorServices = new HashSet<CollaboratorService>();
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public string Duration { get; set; }
    public decimal Price { get; set; }
    public string Color { get; set; }

    public virtual ICollection<TurnDetail> TurnDetails { get; set; }
    public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    public virtual ICollection<CollaboratorService> CollaboratorServices { get; set; }
}
