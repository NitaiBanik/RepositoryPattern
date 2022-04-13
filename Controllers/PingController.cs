using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Controllers;

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
