using BeautySalonManage.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("Roles");

        builder.HasData(new ApplicationRole
        {
            Id = "8b636e0c-962d-44c6-8522-2de6a5886cf8",
            Name = "Administrador",
            IsActive = true,
        },
        new ApplicationRole
        {
            Id = "aa45d325-603c-4dd2-ab8d-fa00a320db3f",
            Name = "Colaborador",
            IsActive = true,
        });

        builder
            .Ignore(u => u.NormalizedName)
            .Ignore(u => u.ConcurrencyStamp);
    }
}
