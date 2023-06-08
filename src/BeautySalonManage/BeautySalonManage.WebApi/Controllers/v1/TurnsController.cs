using BeautySalonManage.Application.Turns.Commands.Create.CreateTurn;
using BeautySalonManage.Application.Turns.Commands.Update.UpdateTurn;
using BeautySalonManage.Application.Turns.Commands.Update.UpdateTurnState;
using BeautySalonManage.Application.Turns.Queries.GetAllTurns;
using BeautySalonManage.Application.Turns.Queries.GetTurnById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1;

[ApiVersion("1.0")]
[Authorize]
public class TurnsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTurnsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await Mediator.Send(new GetTurnByIdQuery() { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateTurnCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, UpdateTurnCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }

    [HttpPut("state/{id}")]
    public async Task<IActionResult> PutState(Guid id, UpdateTurnStateCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }
}