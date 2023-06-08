using Microsoft.AspNetCore.Identity;

namespace BeautySalonManage.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsActive { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime LastModifiedOn { get; set; }
}
