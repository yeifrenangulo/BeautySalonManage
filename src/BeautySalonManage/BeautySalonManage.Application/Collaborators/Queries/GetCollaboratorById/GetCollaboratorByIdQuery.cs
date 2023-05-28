using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Queries.GetCollaboratorById;

public class GetCollaboratorByIdQuery : IRequest<Response<CollaboratorServiceDto>>
{
    public int CollacoratorId { get; set; }
}