using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController
    : ControllerBase
{
    [HttpGet("/ping", Name = "Ping")]
    public ActionResult<string> Get()
    {
        return Ok("Pong");
    }
}
