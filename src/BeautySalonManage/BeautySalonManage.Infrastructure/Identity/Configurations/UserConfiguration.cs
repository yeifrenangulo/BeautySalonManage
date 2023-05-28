using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

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
