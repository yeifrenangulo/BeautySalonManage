﻿namespace BeautySalonManage.Application.Common.Models.Identity;

public class RegistrationRequest
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
