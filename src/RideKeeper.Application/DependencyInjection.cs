using Microsoft.Extensions.DependencyInjection;
using RideKeeper.Application.Health;

namespace RideKeeper.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton(TimeProvider.System);
        services.AddScoped<IHealthService, HealthService>();
        return services;
    }
}
