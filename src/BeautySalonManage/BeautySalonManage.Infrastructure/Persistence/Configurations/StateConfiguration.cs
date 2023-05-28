using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
    public void Configure(EntityTypeBuilder<State> builder)
    {
        builder.ToTable("States");

        builder.Property(e => e.Id)
            .HasComment("Identificador Único del Estado");

        builder.Property(e => e.CreatedBy)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("Usuario de Creación del Registro");

        builder.Property(e => e.CreatedOn)
            .HasColumnType("datetime")
            .HasComment("Fecha de Creación del Registro");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(15)
            .HasComment("Descripción del Estado");

        builder.Property(e => e.IsActive)
            .HasComment("¿Está Activo? (1 = Si, 0 = No)");

        builder.Property(e => e.LastModifiedBy)
            .IsRequired()
            .HasMaxLength(20)
            .HasComment("Usuario de la Última Modificación del Registro");

        builder.Property(e => e.LastModifiedOn)
            .HasColumnType("datetime")
            .HasComment("Fecha de la Última Modificación del Registro");
    }
}
