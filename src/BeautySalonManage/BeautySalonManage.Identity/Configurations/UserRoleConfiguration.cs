using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.ToTable("UserRole");

        builder.HasData(new IdentityUserRole<string>
        {
            RoleId = "8b636e0c-962d-44c6-8522-2de6a5886cf8",
            UserId = "5f53e58e-828a-4818-b208-c2d886768225"
        });
    }
}
