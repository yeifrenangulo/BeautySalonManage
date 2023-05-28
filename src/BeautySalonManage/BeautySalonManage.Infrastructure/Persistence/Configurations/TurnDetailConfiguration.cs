using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class TurnDetailConfiguration : IEntityTypeConfiguration<TurnDetail>
{
    public void Configure(EntityTypeBuilder<TurnDetail> builder)
    {
        builder.HasKey(e => new { e.TurnId, e.CollaboratorId, e.ServiceId })
                .HasName("PK_TurnDetails");

        builder.ToTable("TurnDetails");

        builder.Property(e => e.TurnId).HasComment("Identificador del Turno");

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
            .WithMany(p => p.TurnDetails)
            .HasForeignKey(d => d.CollaboratorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("TurnDetailsCollaborator_FK");

        builder.HasOne(d => d.Service)
            .WithMany(p => p.TurnDetails)
            .HasForeignKey(d => d.ServiceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("TurnDetailsService_FK");

        builder.HasOne(d => d.Turn)
            .WithMany(p => p.TurnDetails)
            .HasForeignKey(d => d.TurnId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("TurnDetailsTurn_FK");
    }
}
