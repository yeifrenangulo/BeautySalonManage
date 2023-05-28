using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class MenuOptionConfiguration : IEntityTypeConfiguration<MenuOption>
{
    public void Configure(EntityTypeBuilder<MenuOption> builder)
    {
        builder.ToTable("MenuOptions");

        builder.Property(e => e.Id)
               .HasComment("Identificador Único de la Opción de Menú");

        builder.Property(e => e.CreatedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasComment("Usuario de Creación del Registro");

        builder.Property(e => e.CreatedOn)
               .HasColumnType("datetime")
               .HasComment("Fecha de Creación del Registro");

        builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(15)
               .HasComment("Descripción de la Opción de Menú");

        builder.Property(e => e.IsActive)
               .HasComment("¿Está Activo? (1 = Si, 0 = No)");

        builder.Property(e => e.LastModifiedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasComment("Usuario de la Última Modificación del Registro");

        builder.Property(e => e.LastModifiedOn)
               .HasColumnType("datetime")
               .HasComment("Fecha de la Última Modificación del Registro");

        builder.Property(e => e.Order)
               .HasComment("Orden de la Opción");

        builder.Property(e => e.ParentOption)
               .HasComment("Opción de Menú Padre");

        builder.Property(e => e.Icon)
               .HasComment("Icono de la Opción");
    }
}
