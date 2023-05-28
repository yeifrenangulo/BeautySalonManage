using Microsoft.AspNetCore.Identity;

namespace BeautySalonManage.Infrastructure.Identity;

public class ApplicationRole : IdentityRole
{
    public bool IsActive { get; set; }
}
