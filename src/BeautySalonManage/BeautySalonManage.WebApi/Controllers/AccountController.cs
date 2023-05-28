using BeautySalonManage.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AccountController : BaseApiController
{
    //[HttpPost("authenticate")]
    //public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
    //{
    //    return Ok(await Mediator.Send(new AuthenticateCommand { 
    //        User = request.User,
    //        Password = request.Password,
    //        IpAddress = GenerateIPAddress()
    //    }));
    //}

    private string GenerateIPAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}
