using Microsoft.AspNetCore.Mvc.Testing;
using Testcontainers.MsSql;

namespace RideKeeper.Api.IntegrationTests;

/// <summary>Starts the real API against a throw-away SQL Server container.</summary>
public sealed class ApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private const string ConnectionStringVariable = "ConnectionStrings__Default";

    private readonly MsSqlContainer _sql = new MsSqlBuilder().Build();

    public async Task InitializeAsync()
    {
        await _sql.StartAsync();

        // Program.cs reads the connection string eagerly while building the host, so it must be
        // visible as an environment variable before the host is created.
        Environment.SetEnvironmentVariable(ConnectionStringVariable, _sql.GetConnectionString());
    }

    public new async Task DisposeAsync()
    {
        await base.DisposeAsync();
        Environment.SetEnvironmentVariable(ConnectionStringVariable, null);
        await _sql.DisposeAsync();
    }
}
