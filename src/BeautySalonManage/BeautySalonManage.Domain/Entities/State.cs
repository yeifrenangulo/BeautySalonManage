using BeautySalonManage.Domain.Common;

namespace BeautySalonManage.Domain.Entities;

public partial class State : BaseEntity
{
    public State()
    {
        Turns = new HashSet<Turn>();
    }

    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Turn> Turns { get; set; }
}
