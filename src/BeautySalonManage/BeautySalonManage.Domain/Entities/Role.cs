using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class Role : BaseEntity
    {
        public Role()
        {
            MenuOptionRoles = new HashSet<MenuOptionRole>();
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MenuOptionRole> MenuOptionRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
