using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Services.Queries;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Collaborators.Commands.Create.CreateCollaborator;

public class CreateCollaboratorCommand : IRequest<Response<int>>, IMapFrom<Collaborator>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string NameContact { get; set; }
    public string PhoneContact { get; set; }
    public int GenderId { get; set; }

    public List<ServicePercentageDto> Services { get; set; }
}