using Microsoft.AspNetCore.Identity;

namespace BeautySalonManage.Identity.Models;

public class ApplicationRole : IdentityRole
{
    public bool IsActive { get; set; }
}
