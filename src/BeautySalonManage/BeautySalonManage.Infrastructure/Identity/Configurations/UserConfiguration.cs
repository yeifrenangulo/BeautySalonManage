using BeautySalonManage.Infrastructure.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("Users");

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(30)
               .HasComment("Nombre del Usuario");

        builder.Property(p => p.Surname)
               .IsRequired()
               .HasMaxLength(30)
               .HasComment("Apellido del Usuario");

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(60)
            .HasComment("Email del Usuario");

        builder.Property(p => p.PasswordHash)
            .HasColumnName("Password")
            .IsRequired();

        builder.Property(p => p.IsActive)
               .IsRequired()
               .HasComment("¿Está Activo? (1 = Si, 0 = No)");

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
            .Ignore(u => u.PhoneNumberConfirmed)
            .Ignore(u => u.AccessFailedCount)
            .Ignore(u => u.EmailConfirmed)
            .Ignore(u => u.SecurityStamp)
            .Ignore(u => u.ConcurrencyStamp)
            .Ignore(u => u.TwoFactorEnabled)
            .Ignore(u => u.LockoutEnd)
            .Ignore(u => u.LockoutEnabled);
    }
}
