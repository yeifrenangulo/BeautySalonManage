using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Commands.Delete.DeleteCollaborator;

public class DeleteCollaboratorCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
}