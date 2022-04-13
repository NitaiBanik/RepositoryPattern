using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<PingController> _logger;

    public WeatherForecastController(ILogger<PingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Ping")]
    public ActionResult<string> Get()
    {
	return Ok("Pong");
    }
}
