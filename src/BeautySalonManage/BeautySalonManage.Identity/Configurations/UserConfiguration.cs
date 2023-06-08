using BeautySalonManage.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        var hasher = new PasswordHasher<ApplicationUser>();

        builder.HasData(new ApplicationUser
        {
            Id = "5f53e58e-828a-4818-b208-c2d886768225",
            Name = "Alexis",
            Surname = "Angulo",
            Email = "yeifrenangulo@gmail.com",
            UserName = "aangulo",
            PasswordHash = hasher.HashPassword(null, "aangulo"),
            IsActive = true
        });

        builder
            .Ignore(u => u.PhoneNumberConfirmed)
            .Ignore(u => u.AccessFailedCount)
            .Ignore(u => u.EmailConfirmed)
            .Ignore(u => u.SecurityStamp)
            .Ignore(u => u.ConcurrencyStamp)
            .Ignore(u => u.NormalizedUserName)
            .Ignore(u => u.NormalizedEmail)
            .Ignore(u => u.TwoFactorEnabled)
            .Ignore(u => u.LockoutEnd)
            .Ignore(u => u.LockoutEnabled);
    }
}
