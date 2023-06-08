using BeautySalonManage.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Identity.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("Roles");

        builder.Property(p => p.CreatedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasDefaultValue("Sistema")
               .HasComment("Usuario de Creación del Regitro");

        builder.Property(p => p.CreatedOn)
               .IsRequired()
               .HasColumnType("datetime")
               .HasDefaultValueSql("(getdate())")
               .HasComment("Fecha de Creación del Registro");

        builder.Property(p => p.LastModifiedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasDefaultValue("Sistema")
               .HasComment("Usuario de la Última Modificación del Regitro");

        builder.Property(p => p.LastModifiedOn)
               .IsRequired()
               .HasColumnType("datetime")
               .HasDefaultValueSql("(getdate())")
               .HasComment("Fecha de la Última Modificación del Registro");

        builder
            .Ignore(u => u.ConcurrencyStamp);
    }
}
