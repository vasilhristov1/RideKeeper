using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RideKeeper.Application.Health;
using RideKeeper.Infrastructure.Persistence;

namespace RideKeeper.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<RideKeeperDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IDatabaseProbe, SqlServerDatabaseProbe>();
        return services;
    }
}
