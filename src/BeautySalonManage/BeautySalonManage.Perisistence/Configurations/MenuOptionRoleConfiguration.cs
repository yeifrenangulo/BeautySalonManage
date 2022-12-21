using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeautySalonManage.Perisistence.Configurations
{
    public class MenuOptionRoleConfiguration : IEntityTypeConfiguration<MenuOptionRole>
    {
        public void Configure(EntityTypeBuilder<MenuOptionRole> builder)
        {
            builder.HasKey(e => new { e.MenuOptionId, e.RoleId })
                   .HasName("PRIMARY")
                   .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            builder.ToTable("menuoptionroles");

            builder.HasComment("Información de Opciones Rol");

            builder.HasIndex(e => e.RoleId, "MenuOptionRoles_RoleId_FK");

            builder.Property(e => e.MenuOptionId).HasComment("Identificador de la Opcion Menu");

            builder.Property(e => e.RoleId).HasComment("Identificador del Rol");

            builder.Property(e => e.AllowCreate).HasComment("Permite Crear en la Opción");

            builder.Property(e => e.AllowRead).HasComment("Permite Consultar en la Opción");

            builder.Property(e => e.AllowRemove).HasComment("Permite Eliminar en la Opción");

            builder.Property(e => e.AllowUpdate).HasComment("Permite Actualizar en la Opción");

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

            builder.HasOne(d => d.MenuOption)
                   .WithMany(p => p.MenuOptionRoles)
                   .HasForeignKey(d => d.MenuOptionId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("MenuOptionRoles_MenuOptionId_FK");

            builder.HasOne(d => d.Role)
                   .WithMany(p => p.MenuOptionRoles)
                   .HasForeignKey(d => d.RoleId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("MenuOptionRoles_RoleId_FK");
        }
    }
}
