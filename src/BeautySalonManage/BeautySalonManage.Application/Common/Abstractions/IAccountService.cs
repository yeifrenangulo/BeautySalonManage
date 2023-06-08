using BeautySalonManage.Application.Common.Models.Account;

namespace BeautySalonManage.Application.Common.Abstractions;

public interface IAccountService
{
    Task<AuthResponse> Login(AuthRequest request);
}
