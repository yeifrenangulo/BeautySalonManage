using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers")
                   .HasComment("Información de los Clientes");

            builder.HasKey(p => p.CustomerId);

            builder.HasIndex(e => new { e.Name, e.Surname })
                   .IsUnique()
                   .HasDatabaseName("IDX_NameSurname");

            builder.Property(p => p.CustomerId)
                   .HasComment("Identificador Único del Cliente");

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasComment("Nombre del Cliente");

            builder.Property(p => p.Surname)
                   .IsRequired()
                   .HasMaxLength(30)
                   .HasComment("Apellido del Cliente");

            builder.Property(p => p.Phone)
                   .IsRequired()
                   .HasMaxLength(15)
                   .HasComment("Teléfono del Cliente");

            builder.Property(p => p.DateBirth)
                   .HasColumnType("datetime")
                   .HasComment("Fecha de Nacimiento del Cliente");

            builder.Property(p => p.GenderId)
                   .IsRequired()
                   .HasComment("Género del Cliente");

            builder.Property(p => p.IsActive)
                   .IsRequired()
                   .HasComment("¿Está Activo? (1 = Si, 0 = No)");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(20)
                   .HasComment("Usuario de Creación del Regitro");

            builder.Property(p => p.CreatedOn)
                   .HasColumnType("datetime")
                   .HasComment("Fecha de Creación del Registro");

            builder.Property(p => p.LastModifiedBy)
                   .HasMaxLength(20)
                   .HasComment("Usuario de la Última Modificación del Regitro");

            builder.Property(p => p.LastModifiedOn)
                   .HasColumnType("datetime")
                   .HasComment("Fecha de la Última Modificación del Registro");

            builder.HasOne(f => f.Gender)
                   .WithMany(p => p.Customers)
                   .HasForeignKey(d => d.GenderId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Customer_Gender_GenderId");
        }
    }
}
