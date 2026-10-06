namespace RideKeeper.Application.Health;

public interface IHealthService
{
    Task<HealthStatusDto> CheckAsync(CancellationToken cancellationToken);
}
