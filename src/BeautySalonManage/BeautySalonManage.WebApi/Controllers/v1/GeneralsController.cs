using BeautySalonManage.Application.Genders.Queries.GetGenders;
using Microsoft.AspNetCore.Mvc;

namespace BeautySalonManage.WebApi.Controllers.v1;

[ApiVersion("1.0")]
public class Generals : BaseApiController
{
    [HttpGet("genders")]
    public async Task<IActionResult> Get()
    {
        return Ok(await Mediator.Send(new GetGendersQuery()));
    }
}
