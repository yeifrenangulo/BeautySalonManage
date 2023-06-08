using BeautySalonManage.Application.Common.Models;
using MediatR;

namespace BeautySalonManage.Application.Turns.Commands.Update.UpdateTurnState;

public class UpdateTurnStateCommand : IRequest<Response<bool>>
{
    public Guid Id { get; set; }
    public int StateId { get; set; }
}