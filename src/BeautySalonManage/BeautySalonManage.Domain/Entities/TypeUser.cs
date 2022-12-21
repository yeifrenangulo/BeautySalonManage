using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class TypeUser : BaseEntity
    {
        public TypeUser()
        {
            Users = new HashSet<User>();
        }

        public int TypeUserId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
