using BeautySalonManage.Application.Features.Collaborators.Commands.Create;
using BeautySalonManage.Application.Features.Collaborators.Commands.Delete;
using BeautySalonManage.Application.Features.Collaborators.Commands.Update;
using BeautySalonManage.Application.Features.Collaborators.Queries;
using BeautySalonManage.Application.Features.Collaborators.Queries.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class CollaboratorsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCollaboratorsParameter parameter)
        {
            return Ok(await Mediator.Send(new GetAllCollaboratorsQuery()
            {
                Name = parameter.Name,
                Surname = parameter.Surname,
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCollaboratorByIdQuery() { CollacoratorId = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateCollaboratorCommand command)
        {
            if (id != command.CollaboratorId)
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
            return Ok(await Mediator.Send(new DeleteCollaboratorCommand() { CollaboratorId = id }));
        }
    }
}
