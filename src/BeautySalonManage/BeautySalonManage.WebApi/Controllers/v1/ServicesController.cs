using BeautySalonManage.Application.Features.Services.Commands.Create;
using BeautySalonManage.Application.Features.Services.Commands.Delete;
using BeautySalonManage.Application.Features.Services.Commands.Update;
using BeautySalonManage.Application.Features.Services.Queries;
using BeautySalonManage.Application.Helpers.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class ServicesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] RequestParameter parameter)
        {
            return Ok(await Mediator.Send(new GetAllServicesQuery()
            {
                PageNumber = parameter.PageNumber,
                PageSize = parameter.PageSize
            }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetServiceByIdQuery() { ServiceId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateServiceCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateServiceCommand command)
        {
            if (id != command.ServiceId)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteServiceCommand() { ServiceId = id }));
        }
    }
}
