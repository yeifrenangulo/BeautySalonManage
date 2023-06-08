using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models.Account;
using BeautySalonManage.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("auth")]
    public async Task<IActionResult> AuthenticateAsync([FromBody] AuthRequest request)
    {
        return Ok(await _accountService.Login(request));
    }

    private string GenerateIPAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
    }
}
