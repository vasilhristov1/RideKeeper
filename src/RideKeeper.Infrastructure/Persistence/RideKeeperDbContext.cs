using Microsoft.EntityFrameworkCore;

namespace RideKeeper.Infrastructure.Persistence;

public sealed class RideKeeperDbContext(DbContextOptions<RideKeeperDbContext> options) : DbContext(options)
{
}
