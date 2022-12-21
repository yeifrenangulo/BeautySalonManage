using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class CollaboratorService : BaseEntity
    {
        public int CollaboratorId { get; set; }
        public int ServiceId { get; set; }
        public decimal Percentage { get; set; }

        public virtual Collaborator Collaborator { get; set; }
        public virtual Service Service { get; set; }
    }
}
