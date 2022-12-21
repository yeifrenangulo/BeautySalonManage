using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class TypeUserConfiguration : IEntityTypeConfiguration<TypeUser>
    {
        public void Configure(EntityTypeBuilder<TypeUser> builder)
        {
            builder.ToTable("typeusers");

            builder.HasComment("Información de los Tipos de Usuarios");

            builder.Property(e => e.TypeUserId).HasComment("Identificador Único del Tipo de Usuario");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de Creación del Registro");

            builder.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación del Registro");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(15)
                .HasComment("Descripción del Tipo de Usuario");

            builder.Property(e => e.IsActive).HasComment("¿está Activo? (1 = Si, 0 = No)");

            builder.Property(e => e.LastModifiedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de la Última Modificación del Registro");

            builder.Property(e => e.LastModifiedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de la Última Modificación del Registro");
        }
    }
}
