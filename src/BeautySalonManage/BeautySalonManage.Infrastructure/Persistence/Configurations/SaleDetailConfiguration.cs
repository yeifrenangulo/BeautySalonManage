using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.HasKey(e => new { e.SaleId, e.CollaboratorId, e.ServiceId })
                .HasName("PK_SaleDetails");

        builder.ToTable("SaleDetails");

        builder.Property(e => e.SaleId).HasComment("Identificador de la Venta");

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

        builder.Property(e => e.Price)
            .HasPrecision(10, 2)
            .HasComment("Precio Servico del Turno");

        builder.HasOne(d => d.Collaborator)
            .WithMany(p => p.SaleDetails)
            .HasForeignKey(d => d.CollaboratorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SaleDetailsCollaborator_FK");

        builder.HasOne(d => d.Service)
            .WithMany(p => p.SaleDetails)
            .HasForeignKey(d => d.ServiceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SaleDetailsService_FK");

        builder.HasOne(d => d.Sale)
            .WithMany(p => p.SaleDetails)
            .HasForeignKey(d => d.SaleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SaleDetailsTurn_FK");
    }
}
