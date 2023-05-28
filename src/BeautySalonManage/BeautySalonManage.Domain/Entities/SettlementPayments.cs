using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class SettlementPayments : BaseEntity
{
    public SettlementPayments()
    {
        SettlementPaymentsDetails = new HashSet<SettlementPaymentsDetail>();    
    }

    public long Id { get; set; }
    public int CollaboratorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Amount { get; set; }
    public string Observation { get; set; }

    public virtual Collaborator Collaborator { get; set; }
    public virtual ICollection<SettlementPaymentsDetail> SettlementPaymentsDetails { get; set; }
}
