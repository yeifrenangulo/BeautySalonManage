using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class CollaboratorConfiguration : IEntityTypeConfiguration<Collaborator>
    {
        public void Configure(EntityTypeBuilder<Collaborator> builder)
        {
            builder.ToTable("collaborators");

            builder.HasComment("Información de los Colaboradores");

            builder.HasIndex(e => e.GenderId, "Collaborator_GenderId_FK");

            builder.HasIndex(e => new { e.Name, e.Surname }, "collaborators_Name_IDX")
                   .IsUnique();

            builder.Property(e => e.CollaboratorId)
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
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasComment("Nombre de Contacto del Colaborador");

            builder.Property(e => e.Phone)
                   .IsRequired()
                   .HasMaxLength(15)
                   .HasComment("Teléfono del Colaborador");

            builder.Property(e => e.PhoneContact)
                   .IsRequired()
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
}
