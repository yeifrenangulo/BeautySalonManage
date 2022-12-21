using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonManage.Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedInfraestructure(this IServiceCollection services)
        {
            services.AddTransient(typeof(IDateService), typeof(DateService));
        }
    }
}
