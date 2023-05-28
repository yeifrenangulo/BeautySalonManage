using BeautySalonManage.Application.Common.Models.Identity;
using BeautySalonManage.Application.Common.Models.Users;

namespace BeautySalonManage.Application.Common.Abstractions;

public interface IIdentityService
{
    Task<AuthenticationResponse> Login(AuthenticationRequest request);
    Task<string> Register(RegistrationRequest request);
}
