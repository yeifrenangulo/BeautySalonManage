using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class SettlementPaymentsConfiguration : IEntityTypeConfiguration<SettlementPayments>
{
    public void Configure(EntityTypeBuilder<SettlementPayments> builder)
    {
        builder.ToTable("SettlementPayments");

        builder.Property(e => e.Id)
            .HasComment("Identificador Único de la Venta");

        builder.Property(e => e.Amount)
            .HasPrecision(10, 2)
            .HasComment("Monto de la Venta");

        builder.Property(e => e.CollaboratorId)
            .HasComment("Identificador del Colaborador");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("Usuario de Creación del Registro");

        builder.Property(e => e.CreatedOn)
            .HasColumnType("datetime")
            .HasComment("Fecha de Creación del Registro");

        builder.Property(e => e.EndDate)
            .IsRequired()
            .HasColumnType("datetime")
            .HasComment("Fecha de Fin de la Liquidación");

        builder.Property(e => e.IsActive)
            .HasComment("¿Está Activo? (1 = Si, 0 = No)");

        builder.Property(e => e.LastModifiedBy)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("Usuario de Última Modificación del Registro");

        builder.Property(e => e.LastModifiedOn)
            .HasColumnType("datetime")
            .HasComment("Fecha Última Modificación del Registro");

        builder.Property(e => e.Observation)
            .HasMaxLength(50)
            .HasComment("Observación de la Venta");

        builder.Property(e => e.StartDate)
            .IsRequired()
            .HasColumnType("datetime")
            .HasComment("Fecha de Inicio de la Liquidación");

        builder.HasOne(f => f.Collaborator)
               .WithMany(p => p.SettlementPayments)
               .HasForeignKey(d => d.CollaboratorId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_SettlementPaymentsCollaboratorId");
    }
}
