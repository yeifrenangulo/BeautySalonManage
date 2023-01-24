using BeautySalonManage.Application.DTOs.Users;
using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Interfaces
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(User usuario, string ipAddress);
    }
}
