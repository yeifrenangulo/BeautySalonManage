using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Genders")
                   .HasComment("Información de los Géneros (1 = Hombre, 2 = Mujer)");

            builder.HasKey(p => p.GenderId);

            builder.Property(p => p.GenderId)
                   .HasComment("Identificador Único del Género");

            builder.Property(p => p.Description)
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
}
