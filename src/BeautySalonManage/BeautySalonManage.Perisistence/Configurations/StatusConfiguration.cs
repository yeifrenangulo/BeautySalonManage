using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class TurnConfiguration : IEntityTypeConfiguration<Turn>
    {
        public void Configure(EntityTypeBuilder<Turn> builder)
        {
            builder.ToTable("turns");

            builder.HasComment("Información de los Turnos");

            builder.HasIndex(e => e.StatusId, "TurnsStatus_FK");

            builder.Property(e => e.TurnId)
                .ValueGeneratedNever()
                .HasComment("Identificador Único del Turno");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de Creación del Registro");

            builder.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación del Registro");

            builder.Property(e => e.EndTime)
                .HasColumnType("time")
                .HasComment("Hora Final del Turno");

            builder.Property(e => e.IsActive).HasComment("¿Está Activo? (1 = Si, 0 = No)");

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
                .HasComment("Nombre del Cliente del Turno");

            builder.Property(e => e.Observation)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Observación del Turno");

            builder.Property(e => e.PhoneCustomer)
                .IsRequired()
                .HasMaxLength(15)
                .HasComment("Teléfono del Cliente del Turno");

            builder.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasComment("Fecha del Turno");

            builder.Property(e => e.StartTime)
                .HasColumnType("time")
                .HasComment("Hora Inicial del Turno");

            builder.Property(e => e.StatusId).HasComment("Identificador del Estado");

            builder.Property(e => e.TotalPrice)
                .HasPrecision(10, 2)
                .HasComment("Precio Total del Turno");

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Turns)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TurnsStatus_FK");
        }
    }
}
