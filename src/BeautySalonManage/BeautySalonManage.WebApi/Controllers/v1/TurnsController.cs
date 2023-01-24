using BeautySalonManage.Application.Features.Turns.Commands.Create.Commands;
using BeautySalonManage.Application.Features.Turns.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    //[Authorize]
    public class TurnsController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllTurnsQuery parameter)
        {
            return Ok(await Mediator.Send(parameter));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateTurnCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
