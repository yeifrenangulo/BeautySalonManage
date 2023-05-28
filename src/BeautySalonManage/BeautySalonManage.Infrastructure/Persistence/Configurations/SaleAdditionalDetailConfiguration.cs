using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class SaleAdditionalDetailConfiguration : IEntityTypeConfiguration<SaleAdditionalDetail>
{
    public void Configure(EntityTypeBuilder<SaleAdditionalDetail> builder)
    {
        builder.ToTable("SaleAdditionalDetails");

        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasComment("Identificador Único del Detalle Adicional de la Venta");

        builder.Property(e => e.CollaboratorId)
            .HasComment("Identificador del Colaborador");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("Usuario de Creación del Registro");

        builder.Property(e => e.CreatedOn)
            .HasColumnType("datetime")
            .HasComment("Fecha de Creación del Registro");

        builder.Property(e => e.Detail)
            .IsRequired()
            .HasMaxLength(100)
            .HasComment("Detalle de la Venta");

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
            .HasComment("Precio detalle de la Venta");

        builder.Property(e => e.SaleId)
            .HasComment("Identificador de la Venta");

        builder.HasOne(d => d.Sale)
            .WithMany(p => p.SaleAdditionalDetails)
            .HasForeignKey(d => d.SaleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SaleAdditionalDetailsSales_FK");

        builder.HasOne(d => d.Collaborator)
            .WithMany(p => p.SaleAdditionalDetails)
            .HasForeignKey(d => d.CollaboratorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("SaleAdditionalDetailsCollaborators_FK");
    }
}
