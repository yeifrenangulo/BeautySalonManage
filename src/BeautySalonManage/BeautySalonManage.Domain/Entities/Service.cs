using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class Service : BaseEntity
    {
        public Service()
        {
            CollaboratorServices = new HashSet<CollaboratorService>();
            TurnDetails = new HashSet<TurnDetail>();
        }

        public int ServiceId { get; set; }
        public string Tittle { get; set; }
        public string Detail { get; set; }
        public string Duration { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CollaboratorService> CollaboratorServices { get; set; }
        public virtual ICollection<TurnDetail> TurnDetails { get; set; }
    }
}
