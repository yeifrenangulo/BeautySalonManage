using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class TurnAdditionalDetail : BaseEntity
    {
        public long TurnAdditionalDetailId { get; set; }
        public long TurnId { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; }

        public virtual Turn Turn { get; set; }
    }
}
