using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class MenuOptionRole : BaseEntity
    {
        public int MenuOptionId { get; set; }
        public int RoleId { get; set; }
        public bool AllowCreate { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowRead { get; set; }
        public bool AllowRemove { get; set; }

        public virtual MenuOption MenuOption { get; set; }
        public virtual Role Role { get; set; }
    }
}
