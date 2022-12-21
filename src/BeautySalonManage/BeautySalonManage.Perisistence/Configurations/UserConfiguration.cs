using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasComment("Información de los Usuarios");

            builder.HasIndex(e => e.TypeUserId, "Users_FK");

            builder.Property(e => e.UserId).HasComment("Identificador Único del Usuario");

            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de Creación del Registro");

            builder.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de Creación de Registro");

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(80)
                .HasComment("Correo Electrónico del Usuario");

            builder.Property(e => e.IsActive).HasComment("¿Estás Activo) (1 = Si, 0 = No)");

            builder.Property(e => e.LastModifiedBy)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Usuario de Última Modificación del Registro");

            builder.Property(e => e.LastModifiedOn)
                .HasColumnType("datetime")
                .HasComment("Fecha de Última Modificación de Registro");

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("Contraseña del Usuario");

            builder.Property(e => e.TypeUserId).HasComment("Identificador del Tipo de Usuario");

            builder.Property(e => e.User1)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("User")
                .HasComment("Login del Usuario");

            builder.HasOne(d => d.TypeUser)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.TypeUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Users_FK");
        }
    }
}
