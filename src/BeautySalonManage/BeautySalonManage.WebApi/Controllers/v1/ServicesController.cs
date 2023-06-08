using BeautySalonManage.Application.Services.Commands.Create.CreateService;
using BeautySalonManage.Application.Services.Commands.Delete.DeleteService;
using BeautySalonManage.Application.Services.Commands.Update.UpdateService;
using BeautySalonManage.Application.Services.Queries.GetAllServices;
using BeautySalonManage.Application.Services.Queries.GetServiceById;
using BeautySalonManage.Application.Services.Queries.GetServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1;

[ApiVersion("1.0")]
[Authorize]
public class ServicesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetServicesQuery query)
    {
        return Ok(await Mediator.Send(query));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await Mediator.Send(new GetServiceByIdQuery() { ServiceId = id }));
    }

    [HttpGet("collaborators")]
    public async Task<IActionResult> GetServicesCollaborators()
    {
        return Ok(await Mediator.Send(new GetAllServicesQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateServiceCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateServiceCommand command)
    {
        if (id != command.Id)
            return BadRequest();

        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await Mediator.Send(new DeleteServiceCommand() { Id = id }));
    }
}
