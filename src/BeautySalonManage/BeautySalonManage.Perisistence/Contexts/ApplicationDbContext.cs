using BeautySalonManage.Application.Helpers.Constants;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Domain.Common;
using BeautySalonManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BeautySalonManage.Perisistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateService _dateTime;
        private readonly ICurrentUserService _currentUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateService dateTime, ICurrentUserService currentUserService) 
            : base(options)
        {
            _dateTime = dateTime;
            _currentUserService = currentUserService;
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Collaborator> Collaborators { get; set; }
        public virtual DbSet<CollaboratorService> CollaboratorServices { get; set; }
        public virtual DbSet<MenuOption> MenuOptions { get; set; }
        public virtual DbSet<MenuOptionRole> MenuOptionRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Turn> Turns { get; set; }
        public virtual DbSet<TurnAdditionalDetail> TurnAdditionalDetails { get; set; }
        public virtual DbSet<TurnDetail> TurnsDetails { get; set; }
        public virtual DbSet<TypeUser> TypeUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellation = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsActive = true;

                        entry.Entity.CreatedBy =  _currentUserService.GetUserAsync() ?? ValuesConstant.USER_DEFAULT;
                        entry.Entity.LastModifiedBy = _currentUserService.GetUserAsync() ?? ValuesConstant.USER_DEFAULT;
                        entry.Entity.CreatedOn = _dateTime.LocalTimeNow();
                        entry.Entity.LastModifiedOn = _dateTime.LocalTimeNow();
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTime.LocalTimeNow();
                        entry.Entity.LastModifiedBy = _currentUserService.GetUserAsync() ?? ValuesConstant.USER_DEFAULT;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellation);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
