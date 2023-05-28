using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models;
using BeautySalonManage.Domain.Entities;
using MediatR;

namespace BeautySalonManage.Application.Turns.Commands.Update.UpdateTurnState;

public class UpdateTurnStateCommand : IRequest<Response<bool>>
{
    public long Id { get; set; }
    public int StateId { get; set; }
}