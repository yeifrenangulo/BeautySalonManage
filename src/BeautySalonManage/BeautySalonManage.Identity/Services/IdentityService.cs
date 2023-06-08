using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Application.Common.Models.Identity;
using BeautySalonManage.Application.Common.Models.Users;
using BeautySalonManage.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace BeautySalonManage.Identity.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public IdentityService(
        UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager, 
        JwtSettings jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        var user = await _userManager.FindByLoginAsync(request.User, request.Password);
    }

    public Task<string> Register(RegistrationRequest request)
    {
        throw new NotImplementedException();
    }
}
