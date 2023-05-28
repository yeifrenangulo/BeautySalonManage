using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Genders.Queries;

public class GenderDto : IMapFrom<Gender>
{
    public int Id { get; set; }
    public string Name { get; set; }
}
