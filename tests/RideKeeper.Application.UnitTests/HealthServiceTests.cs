using RideKeeper.Application.Health;

namespace RideKeeper.Application.UnitTests;

public class HealthServiceTests
{
    private sealed class FakeProbe(bool reachable) : IDatabaseProbe
    {
        public Task<bool> CanConnectAsync(CancellationToken cancellationToken) => Task.FromResult(reachable);
    }

    private sealed class FixedTimeProvider(DateTimeOffset now) : TimeProvider
    {
        public override DateTimeOffset GetUtcNow() => now;
    }

    [Theory]
    [InlineData(true, "Healthy")]
    [InlineData(false, "Degraded")]
    public async Task CheckAsync_ReportsStatusFromDatabaseProbe(bool reachable, string expected)
    {
        var now = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var sut = new HealthService(new FakeProbe(reachable), new FixedTimeProvider(now));

        var result = await sut.CheckAsync(CancellationToken.None);

        result.Status.Should().Be(expected);
        result.DatabaseReachable.Should().Be(reachable);
        result.CheckedAt.Should().Be(now);
    }
}
