using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Turns.Queries.GetTurnById;

public class GetTurnByIdQuery : IRequest<Response<TurnDto>>
{
    public long Id { get; set; }
}