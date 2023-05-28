using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Services.Queries;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Commands.Update.UpdateCollaborator;

public class UpdateCollaboratorCommand : IRequest<Response<int>>
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string NameContact { get; set; }
    public string PhoneContact { get; set; }
    public int GenderId { get; set; }

    public List<ServicePercentageDto> Services { get; set; }
}