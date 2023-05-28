using BeautySalonManage.Application.Collaborators.Queries.Parameters;
using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Queries.GetAllCollaborators;

public class GetAllCollaboratorsQuery : GetAllCollaboratorsParameter, IRequest<PagedResponse<List<CollaboratorServiceDto>>>
{
}