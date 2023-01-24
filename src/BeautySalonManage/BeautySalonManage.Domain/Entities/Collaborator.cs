using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{

    public partial class Collaborator : BaseEntity
    {
        public Collaborator()
        {
            CollaboratorServices = new HashSet<CollaboratorService>();
            TurnDetails = new HashSet<TurnDetail>();
        }

        public int CollaboratorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string NameContact { get; set; }
        public string PhoneContact { get; set; }
        public int GenderId { get; set; }
        public string Color { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<CollaboratorService> CollaboratorServices { get; set; }
        public virtual ICollection<TurnDetail> TurnDetails { get; set; }
    }
}
