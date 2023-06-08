using BeautySalonManage.Application.Common.Abstractions;
using System.Security.Claims;

namespace BeautySalonManage.WebApi.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _contextAccessor;
    public CurrentUserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetUser()
    {
        return _contextAccessor.HttpContext?.User?.FindFirstValue("username");
    }
}
