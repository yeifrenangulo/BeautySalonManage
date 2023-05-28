using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.Domain.Common;
using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BeautySalonManage.Application.Common.Constants;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BeautySalonManage.Infrastructure.Identity;
using BeautySalonManage.Infrastructure.Identity.Configurations;
using Microsoft.AspNetCore.Identity;

namespace BeautySalonManage.Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    //private readonly ICurrentUserService _currentUserService;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        //_currentUserService = currentUserService;
    }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Gender> Genders { get; set; }
    public virtual DbSet<Collaborator> Collaborators { get; set; }
    public virtual DbSet<CollaboratorService> CollaboratorServices { get; set; }
    public virtual DbSet<MenuOption> MenuOptions { get; set; }
    public virtual DbSet<Service> Services { get; set; }
    public virtual DbSet<State> States { get; set; }
    public virtual DbSet<Turn> Turns { get; set; }
    public virtual DbSet<TurnAdditionalDetail> TurnAdditionalDetails { get; set; }
    public virtual DbSet<TurnDetail> TurnsDetails { get; set; }


    public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.IsActive = true;

                    entry.Entity.CreatedBy =  ValuesConstant.USER_DEFAULT;
                    entry.Entity.LastModifiedBy = ValuesConstant.USER_DEFAULT;
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.LastModifiedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.Now;
                    entry.Entity.LastModifiedBy = ValuesConstant.USER_DEFAULT;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellation);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
    }
}
