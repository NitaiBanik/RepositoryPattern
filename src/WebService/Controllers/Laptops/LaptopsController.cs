using Domain.Laptops;
using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<ActionResult> AddLaptopAsync(
        [FromBody] AddLaptopRequest request)
    {
        var laptop = new Laptop(
            request.Brand,
            request.Processor,
            request.Generation,
            request.Ram,
            request.SSD,
            request.Cache,
            request.MonitorSize);

        await _laptopRepository.SaveAsync(laptop);

        return Ok();
    }

    [HttpPut("/{id}", Name = "UpdateLaptop")]
    public async Task<ActionResult> UpdateLaptopAsync(
        [FromRoute] string id,
        [FromBody] UpdateLaptopRequest request)
    {
        var laptop = await _laptopRepository.GetAsync(id);
        if (laptop == null)
        {
            return NotFound();
        }

        var newLaptop = new Laptop(
            request.Brand,
            request.Processor,
            request.Generation,
            request.Ram,
            request.SSD,
            request.Cache,
            request.MonitorSize);

        newLaptop.SetId(id);
        await _laptopRepository.UpdateAsync(newLaptop);

        return Ok();
    }

    [HttpPatch("/{id}", Name = "ModifyLaptop")]
    public async Task<ActionResult> ModiftLaptopAsync(
        [FromRoute] string id,
        [FromBody] UpdatedLaptop updatedLaptop)
    {
        await _laptopRepository.ModifyAsync(id, updatedLaptop);
        return Ok();
    }

    [HttpDelete("/{id}", Name = "DeleteLaptop")]
    public async Task<ActionResult> RemoveLaptopAsync(
        [FromRoute] string id)
    {
        await _laptopRepository.DeleteAsync(id);

        return Ok();
    }
}
