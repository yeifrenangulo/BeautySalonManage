using BeautySalonManage.Application.Helpers.Parameters;

namespace BeautySalonManage.Application.Features.Collaborators.Queries.Parameters
{
    public class GetAllCollaboratorsParameter : RequestParameter
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
