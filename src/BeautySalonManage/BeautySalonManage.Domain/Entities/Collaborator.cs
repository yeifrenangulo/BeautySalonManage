using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;


public partial class Collaborator : BaseEntity
{
    public Collaborator()
    {
        TurnDetails = new HashSet<TurnDetail>();
        SaleDetails = new HashSet<SaleDetail>();
        SettlementPayments = new HashSet<SettlementPayments>();
        CollaboratorServices = new HashSet<CollaboratorService>();
        TurnAdditionalDetails = new HashSet<TurnAdditionalDetail>();
        SaleAdditionalDetails = new HashSet<SaleAdditionalDetail>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string NameContact { get; set; }
    public string PhoneContact { get; set; }
    public int GenderId { get; set; }

    public virtual Gender Gender { get; set; }
    public virtual ICollection<TurnDetail> TurnDetails { get; set; }
    public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    public virtual ICollection<SettlementPayments> SettlementPayments { get; set; }
    public virtual ICollection<CollaboratorService> CollaboratorServices { get; set; }
    public virtual ICollection<TurnAdditionalDetail> TurnAdditionalDetails { get; set; }
    public virtual ICollection<SaleAdditionalDetail> SaleAdditionalDetails { get; set; }
}
