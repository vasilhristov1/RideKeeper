using System.Net;
using System.Net.Http.Json;
using RideKeeper.Application.Health;

namespace RideKeeper.Api.IntegrationTests;

public class HealthEndpointTests(ApiFactory factory) : IClassFixture<ApiFactory>
{
    [Fact]
    public async Task Get_ReturnsHealthy_WhenDatabaseIsReachable()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/api/v1/health");

        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var body = await response.Content.ReadFromJsonAsync<HealthStatusDto>(TestContext.Current.CancellationToken);
        body!.Status.Should().Be("Healthy");
        body.DatabaseReachable.Should().BeTrue();
    }
}
