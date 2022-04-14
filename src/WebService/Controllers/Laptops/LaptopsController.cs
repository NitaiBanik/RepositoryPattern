using Domain.Laptops;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers.Laptops;

[ApiController]
[Route("[controller]")]
public class LaptopsController
    : ControllerBase
{
    private readonly ILaptopRepository _laptopRepository;

    public LaptopsController(
        ILaptopRepository laptopRepository)
    {
        _laptopRepository = laptopRepository;
    }

    [HttpGet(Name = "GetAllLaptops")]
    public async Task<ActionResult<IReadOnlyList<Laptop>>> GetAllAsync()
    {
        var laptops = await _laptopRepository.GetAllAsync();
        return Ok(laptops);
    }

    [HttpGet("/{id}", Name = "GetLaptop")]
    public async Task<ActionResult<Laptop?>> GetAsync(
        [FromRoute] string id)
    {
        var laptop = await _laptopRepository.GetAsync(id);
        return Ok(laptop);
    }

    [HttpPost(Name = "AddLaptop")]
    public async Task<ActionResult<Laptop>> AddLaptopAsync(
        [FromBody] AddLaptopRequest request)
    {
        var laoptop = new Laptop(
            request.Brand,
            request.Processor,
            request.Generation,
            request.Ram,
            request.SSD,
            request.Cache,
            request.MonitorSize);

        await _laptopRepository.SaveAsync(laoptop);

        return Ok(laoptop);
    }
}
