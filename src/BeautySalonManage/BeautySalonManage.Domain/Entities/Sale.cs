using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class Sale : BaseEntity
{
    public Sale()
    {
        SaleDetails = new HashSet<SaleDetail>();
        SaleAdditionalDetails = new HashSet<SaleAdditionalDetail>();
        SettlementPaymentsDetails = new HashSet<SettlementPaymentsDetail>();
    }

    public long Id { get; set; }
    public DateTime DateSale { get; set; }
    public string NameCustomer { get; set; }
    public string PhoneCustomer { get; set; }
    public string Observation { get; set; }
    public double Amount { get; set; }
    public long? TurnId { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    public virtual ICollection<SaleAdditionalDetail> SaleAdditionalDetails { get; set; }
    public virtual ICollection<SettlementPaymentsDetail> SettlementPaymentsDetails { get; set; }
}
