namespace RideKeeper.Application.Health;

public sealed class HealthService(IDatabaseProbe databaseProbe, TimeProvider timeProvider) : IHealthService
{
    public async Task<HealthStatusDto> CheckAsync(CancellationToken cancellationToken)
    {
        var reachable = await databaseProbe.CanConnectAsync(cancellationToken);
        return new HealthStatusDto(reachable ? "Healthy" : "Degraded", reachable, timeProvider.GetUtcNow());
    }
}
