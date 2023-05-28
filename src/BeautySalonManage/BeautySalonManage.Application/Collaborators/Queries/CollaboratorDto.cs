using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Collaborators.Queries;

public class CollaboratorDto : IMapFrom<Collaborator>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}
