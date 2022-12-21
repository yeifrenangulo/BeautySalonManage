using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("services");

            builder.HasComment("Información de los Servicios");

            builder.Property(e => e.ServiceId).HasComment("Identificador Único del Servicio");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de Creación del Registro");

            builder.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación de Registro");

            builder.Property(e => e.Detail)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Detalle del Servicio");

            builder.Property(e => e.Duration)
                .IsRequired()
                .HasMaxLength(10)
                .HasComment("Duración del Servicio");

            builder.Property(e => e.IsActive).HasComment("¿Estás Activo) (1 = Si, 0 = No)");

            builder.Property(e => e.LastModifiedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de Última Modificación del Registro");

            builder.Property(e => e.LastModifiedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de Última Modificación de Registro");

            builder.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasComment("Precio del Servicio");

            builder.Property(e => e.Tittle)
                .IsRequired()
                .HasMaxLength(30)
                .HasComment("Titulo del Servicio");
        }
    }
}
