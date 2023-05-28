using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Infrastructure.Persistence.Configurations;

public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
{
    public void Configure(EntityTypeBuilder<Collaborator> builder)
    {
        builder.ToTable("Collaborators");

        builder.HasIndex(e => e.GenderId, "FK_CollaboratorGenderId");

        builder.HasIndex(e => new { e.Name, e.Surname }, "IDX_CollaboratorsName")
               .IsUnique();

        builder.Property(e => e.Id)
               .HasComment("Identificador Único del Colaborador");

        builder.Property(e => e.Address)
               .IsRequired()
               .HasMaxLength(30)
               .HasComment("Dirección del Colaborador");

        builder.Property(e => e.CreatedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasComment("Usuario de Creación del Registro");

        builder.Property(e => e.CreatedOn)
               .HasColumnType("datetime")
               .HasComment("Fecha de Creación de Registro");

        builder.Property(e => e.Email)
               .IsRequired()
               .HasMaxLength(30)
               .HasComment("Email del Colaborador");

        builder.Property(e => e.GenderId)
               .HasComment("Género del Colaborador");

        builder.Property(e => e.IsActive)
               .HasComment("¿Estás Activo) (1 = Si, 0 = No)");

        builder.Property(e => e.LastModifiedBy)
               .IsRequired()
               .HasMaxLength(20)
               .HasComment("Usuario de Última Modificación del Registro");

        builder.Property(e => e.LastModifiedOn)
               .HasColumnType("datetime")
               .HasComment("Fecha de Última Modificación de Registro");

        builder.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(30)
               .HasComment("Nombre del Colaborador");

        builder.Property(e => e.NameContact)
               .HasMaxLength(30)
               .HasComment("Nombre de Contacto del Colaborador");

        builder.Property(e => e.Phone)
               .IsRequired()
               .HasMaxLength(15)
               .HasComment("Teléfono del Colaborador");

        builder.Property(e => e.PhoneContact)
               .HasMaxLength(15)
               .HasComment("Teléfono de Contacto del Colaborador");

        builder.Property(e => e.Surname)
               .IsRequired()
               .HasMaxLength(30)
               .HasComment("Apellido del Colaborador");

        builder.HasOne(d => d.Gender)
               .WithMany(p => p.Collaborators)
               .HasForeignKey(d => d.GenderId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Collaborator_GenderId_FK");
    }
}
