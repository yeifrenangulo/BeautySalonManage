using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class SettlementPaymentsDetail : BaseEntity
{
    public Guid SettlementPaymentsId { get; set; }
    public Guid SaleId { get; set; }

    public virtual Sale Sale { get; set; }
    public virtual SettlementPayments SettlementPayment { get; set; }
}
