using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Persistence.Contexts;
using BeautySalonManage.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeautySalonManage.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        }
    }
}
