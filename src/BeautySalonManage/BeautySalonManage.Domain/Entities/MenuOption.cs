using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class MenuOption : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? ParentOption { get; set; }
    public string Icon { get; set; }
    public int Order { get; set; }
}
