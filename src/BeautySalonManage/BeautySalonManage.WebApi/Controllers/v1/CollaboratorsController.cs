using BeautySalonManage.Application.Collaborators.Commands.Create.CreateCollaborator;
using BeautySalonManage.Application.Collaborators.Commands.Delete.DeleteCollaborator;
using BeautySalonManage.Application.Collaborators.Commands.Update.UpdateCollaborator;
using BeautySalonManage.Application.Collaborators.Queries.GetAllCollaborators;
using BeautySalonManage.Application.Collaborators.Queries.GetCollaboratorById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1;

[ApiVersion("1.0")]
[Authorize]
public class CollaboratorsController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllCollaboratorsQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetCollaboratorByIdQuery() { CollacoratorId = id }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateCollaboratorCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCollaboratorCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteCollaboratorCommand() { Id = id }));
    }
}
