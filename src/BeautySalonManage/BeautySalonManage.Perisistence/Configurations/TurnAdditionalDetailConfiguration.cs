using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class TurnAdditionalDetailConfiguration : IEntityTypeConfiguration<TurnAdditionalDetail>
    {
        public void Configure(EntityTypeBuilder<TurnAdditionalDetail> builder)
        {
            builder.ToTable("turnadditionaldetails");

            builder.HasComment("Información de los Detalles Adicionales de los Turnos");

            builder.HasIndex(e => e.TurnId, "TurnAdditionalDetailsTurns_FK");

            builder.Property(e => e.TurnAdditionalDetailId)
                .ValueGeneratedNever()
                .HasComment("Identificador Único del Detalle Adicional del Turno");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de Creación del Registro");

            builder.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación del Registro");

            builder.Property(e => e.Detail)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("Detalle del Turno");

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
                .HasComment("Precio detalle del Turno");

            builder.Property(e => e.TurnId).HasComment("Identificador del Turno");

            builder.HasOne(d => d.Turn)
                .WithMany(p => p.TurnAdditionalDetails)
                .HasForeignKey(d => d.TurnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TurnAdditionalDetailsTurns_FK");
        }
    }
}
