using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class SettlementPaymentsDetailConfiguration : IEntityTypeConfiguration<SettlementPaymentsDetail>
{
    public void Configure(EntityTypeBuilder<SettlementPaymentsDetail> builder)
    {
        builder.HasKey(e => new { e.SettlementPaymentsId, e.SaleId })
                .HasName("PK_SettlementPaymentsDetails");

        builder.ToTable("SettlementPaymentsDetails");

        builder.Property(e => e.SettlementPaymentsId)
            .HasComment("Identificador Único de la Liquidación");

        builder.Property(e => e.SaleId)
            .HasComment("Identificador Único de la Venta");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("Usuario de Creación del Registro");

        builder.Property(e => e.CreatedOn)
            .HasColumnType("datetime")
            .HasComment("Fecha de Creación del Registro");

        builder.Property(e => e.IsActive)
            .HasComment("¿Está Activo? (1 = Si, 0 = No)");

        builder.Property(e => e.LastModifiedBy)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("Usuario de Última Modificación del Registro");

        builder.Property(e => e.LastModifiedOn)
            .HasColumnType("datetime")
            .HasComment("Fecha Última Modificación del Registro");

        builder.HasOne(f => f.Sale)
               .WithMany(p => p.SettlementPaymentsDetails)
               .HasForeignKey(d => d.SaleId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_SettlementPaymentsDetailsSaleId");

        builder.HasOne(f => f.SettlementPayment)
               .WithMany(p => p.SettlementPaymentsDetails)
               .HasForeignKey(d => d.SettlementPaymentsId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_SettlementPaymentsDetailsettlementPaymentsId");
    }
}
