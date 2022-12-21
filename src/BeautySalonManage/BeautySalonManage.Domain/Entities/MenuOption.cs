using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities
{
    public partial class MenuOption : BaseEntity
    {
        public MenuOption()
        {
            MenuOptionRoles = new HashSet<MenuOptionRole>();
        }

        public int MenuOptionId { get; set; }
        public string Description { get; set; }
        public int? ParentOption { get; set; }
        public int Order { get; set; }

        public virtual ICollection<MenuOptionRole> MenuOptionRoles { get; set; }
    }
}
