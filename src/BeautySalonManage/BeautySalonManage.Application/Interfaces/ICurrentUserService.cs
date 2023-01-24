using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string GetUserAsync();
    }
}
