using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class CollaboratorServicesConfiguration : IEntityTypeConfiguration<CollaboratorService>
    {
        public void Configure(EntityTypeBuilder<CollaboratorService> builder)
        {
            builder.HasKey(e => new { e.CollaboratorId, e.ServiceId })
                   .HasName("PK_CollaboratorServices");

            builder.ToTable("CollaboratorServices");

            builder.HasComment("Información de Servicio por Colaborador");

            builder.Property(e => e.CollaboratorId).HasComment("Identificador del Colaborador");

            builder.Property(e => e.ServiceId).HasComment("Identificador del Servicio");

            builder.Property(e => e.CreatedBy)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasComment("Usuario de Creación del Registro");

            builder.Property(e => e.CreatedOn)
                   .HasColumnType("datetime")
                   .HasComment("Fecha de Creación del Registro");

            builder.Property(e => e.IsActive).HasComment("¿Está Activo? (1 = Si, 0 = No)");

            builder.Property(e => e.LastModifiedBy)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasComment("Usuario de Última Modificación del Registro");

            builder.Property(e => e.LastModifiedOn)
                   .HasColumnType("datetime")
                   .HasComment("Fecha Última Modificación del Registro");

            builder.Property(e => e.Percentage)
                   .HasPrecision(5, 2)
                   .HasComment("Porcentaje del Servicio");

            builder.HasOne(d => d.Collaborator)
                   .WithMany(p => p.CollaboratorServices)
                   .HasForeignKey(d => d.CollaboratorId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("CollaboratorServices_CollaboratorId_FK");

            builder.HasOne(d => d.Service)
                   .WithMany(p => p.CollaboratorServices)
                   .HasForeignKey(d => d.ServiceId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("CollaboratorServices_ServiceId_FK");
        }
    }
}
