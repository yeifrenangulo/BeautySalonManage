using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class Turn : BaseEntity
{
    public Turn()
    {
        TurnAdditionalDetails = new HashSet<TurnAdditionalDetail>();
        TurnDetails = new HashSet<TurnDetail>();
    }

    public Guid Id { get; set; }
    public long NumberTurn { get; set; }
    public DateTime StartDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string NameCustomer { get; set; }
    public string PhoneCustomer { get; set; }
    public string Observation { get; set; }
    public int StateId { get; set; }

    public virtual State States { get; set; }
    public virtual ICollection<TurnAdditionalDetail> TurnAdditionalDetails { get; set; }
    public virtual ICollection<TurnDetail> TurnDetails { get; set; }
}
