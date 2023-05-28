using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class SettlementPaymentsDetail : BaseEntity
{
    public long SettlementPaymentsId { get; set; }
    public long SaleId { get; set; }

    public virtual Sale Sale { get; set; }
    public virtual SettlementPayments SettlementPayment { get; set; }
}
