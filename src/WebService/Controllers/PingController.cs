using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController 
    : ControllerBase
{
    [HttpGet("/ping", Name = "Ping")]
    public ActionResult<string> Get()
    {
        return Ok("Pong");
    }
}
