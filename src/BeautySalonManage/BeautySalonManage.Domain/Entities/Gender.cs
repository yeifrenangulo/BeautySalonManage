using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public class Gender : BaseEntity
    {
        public Gender()
        {
            Collaborators = new HashSet<Collaborator>();
            Customers = new HashSet<Customer>();
        }

        public int GenderId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Collaborator> Collaborators { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
