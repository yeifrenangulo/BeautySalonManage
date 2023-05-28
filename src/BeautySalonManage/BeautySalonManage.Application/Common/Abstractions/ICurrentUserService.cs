using BeautySalonManage.Domain.Entities;

namespace BeautySalonManage.Application.Common.Abstractions
{
    public interface ICurrentUserService
    {
        string GetUserAsync();
    }
}
