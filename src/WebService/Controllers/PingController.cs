using Domain.Laptops;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController
    : ControllerBase
{
    private readonly ILaptopRepository _laptopRepository;

    public PingController(
        ILaptopRepository laptopRepository)
    {
        _laptopRepository = laptopRepository;
    }
    [HttpGet("/ping", Name = "Ping")]
    public async Task<ActionResult<string>> GetAsync()
    {
        var id = Guid.NewGuid().ToString();

        var laoptop = await _laptopRepository.GetAsync(id);

        var lp = new Laptop(
            "a",
            "b",
            "c",
            "D",
            "E",
            "F",
            "G");
        await _laptopRepository.SaveAsync(lp);

        laoptop = await _laptopRepository.GetAsync(lp.ItemId);

        return Ok("Pong");
    }
}
