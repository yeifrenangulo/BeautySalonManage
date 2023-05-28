using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.Property(e => e.Amount)
            .HasPrecision(10, 2)
            .HasComment("Monto de la Venta");

        builder.Property(e => e.Id)
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

        builder.Property(e => e.NameCustomer)
            .IsRequired()
            .HasMaxLength(40)
            .HasComment("Nombre del Cliente de la Venta");

        builder.Property(e => e.Observation)
            .HasMaxLength(50)
            .HasComment("Observación de la Venta");

        builder.Property(e => e.PhoneCustomer)
            .IsRequired()
            .HasMaxLength(15)
            .HasComment("Teléfono del Cliente de la Venta");

        builder.Property(e => e.DateSale)
            .HasColumnType("datetime")
            .HasComment("Fecha del Turno");

        builder.Property(e => e.TurnId)
            .HasComment("Turno asociado a la Vente");
    }
}
