using BeautySalonManage.Application.Common.Models;

namespace BeautySalonManage.Application.Collaborators.Queries.Parameters;

public class GetAllCollaboratorsParameter : RequestParameter
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
