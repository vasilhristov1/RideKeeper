namespace RideKeeper.Application.Health;

public sealed record HealthStatusDto(string Status, bool DatabaseReachable, DateTimeOffset CheckedAt);
