using Microsoft.AspNetCore.Mvc;
using RideKeeper.Application.Health;

namespace RideKeeper.Api.Controllers;

[ApiController]
[Route("api/v1/health")]
public sealed class HealthController(IHealthService healthService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<HealthStatusDto>(StatusCodes.Status200OK)]
    public async Task<ActionResult<HealthStatusDto>> Get(CancellationToken cancellationToken)
        => Ok(await healthService.CheckAsync(cancellationToken));
}
