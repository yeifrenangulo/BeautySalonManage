using BeautySalonManage.Application.Common.Mappings;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Application.Turns.Queries;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Turns.Commands.Create.CreateTurn;

public class CreateTurnCommand : IRequest<Response<Guid>>, IMapFrom<Turn>
{
    public string NameCustomer { get; set; }
    public string PhoneCustomer { get; set; }
    public DateTime StartDate { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Observation { get; set; }

    public List<TurnDetailDto> Details { get; set; }
    public List<TurnAdditionalDetailDto> AdditionalDetails { get; set; }
}