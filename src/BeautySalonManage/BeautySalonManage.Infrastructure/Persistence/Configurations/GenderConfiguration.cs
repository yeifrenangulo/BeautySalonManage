using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Genders");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
               .HasComment("Identificador Único del Género");

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(15)
               .HasComment("Descripción del Género");

        builder.Property(p => p.IsActive)
               .IsRequired()
               .HasComment("¿Está Activo? (1 = Si, 0 = No)");

        builder.Property(p => p.CreatedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasComment("Usuario de Creación del Regitro");

        builder.Property(p => p.CreatedOn)
               .IsRequired()
               .HasColumnType("datetime")
               .HasComment("Fecha de Creación del Registro");

        builder.Property(p => p.LastModifiedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasComment("Usuario de la Última Modificación del Regitro");

        builder.Property(p => p.LastModifiedOn)
               .IsRequired()
               .HasColumnType("datetime")
               .HasComment("Fecha de la Última Modificación del Registro");
    }
}
