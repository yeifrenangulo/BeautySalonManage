using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public class Gender : BaseEntity
{
    public Gender()
    {
        Collaborators = new HashSet<Collaborator>();
        Customers = new HashSet<Customer>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Collaborator> Collaborators { get; set; }
    public virtual ICollection<Customer> Customers { get; set; }
}
