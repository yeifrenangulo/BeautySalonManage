using BeautySalonManage.Application.Common.Abstractions;
using BeautySalonManage.WebApi.Extensions;
using BeautySalonManage.WebApi.Services;

namespace BeautySalonManage.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddControllers();
        services.AddApiVersioningExtension();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerExtension();

        return services;
    }
}
