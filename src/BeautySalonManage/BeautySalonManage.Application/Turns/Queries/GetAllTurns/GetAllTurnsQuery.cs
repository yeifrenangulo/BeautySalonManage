using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Turns.Queries.GetAllTurns;

public class GetAllTurnsQuery : IRequest<Response<List<TurnDto>>>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}