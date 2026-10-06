using RideKeeper.Application.Health;

namespace RideKeeper.Infrastructure.Persistence;

internal sealed class SqlServerDatabaseProbe(RideKeeperDbContext dbContext) : IDatabaseProbe
{
    public async Task<bool> CanConnectAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await dbContext.Database.CanConnectAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
