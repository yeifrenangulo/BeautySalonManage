﻿using Microsoft.AspNetCore.Identity;

namespace BeautySalonManage.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsActive { get; set; }
}
