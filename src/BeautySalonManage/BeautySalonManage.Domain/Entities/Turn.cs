using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class Turn : BaseEntity
    {
        public Turn()
        {
            TurnAdditionalDetails = new HashSet<TurnAdditionalDetail>();
            TurnDetails = new HashSet<TurnDetail>();
        }

        public long TurnId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public decimal TotalPrice { get; set; }
        public string Observation { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual ICollection<TurnAdditionalDetail> TurnAdditionalDetails { get; set; }
        public virtual ICollection<TurnDetail> TurnDetails { get; set; }
    }
}
