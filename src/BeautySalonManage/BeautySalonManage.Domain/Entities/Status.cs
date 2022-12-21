using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class Status : BaseEntity
    {
        public Status()
        {
            Turns = new HashSet<Turn>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Turn> Turns { get; set; }
    }
}
