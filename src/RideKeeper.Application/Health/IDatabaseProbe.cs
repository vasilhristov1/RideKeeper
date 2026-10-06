namespace RideKeeper.Application.Health;

/// <summary>
/// Port implemented by Infrastructure (Adapter pattern) so Application never depends on EF Core.
/// </summary>
public interface IDatabaseProbe
{
    Task<bool> CanConnectAsync(CancellationToken cancellationToken);
}
