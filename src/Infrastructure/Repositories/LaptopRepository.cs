using Domain.Configurations.Repositories;
using Domain.Laptops;

namespace Infrastructure.Repositories;

public class LaptopRepository
    : ILaptopRepository
{
    private readonly IRepository _repository;

    public LaptopRepository(
        IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<Laptop>> GetAllAsync()
    {
        return await _repository.GetAllAsync<Laptop>();
    }

    public async Task<Laptop?> GetAsync(string id)
    {
        return await _repository.GetAsync<Laptop>(id);
    }

    public async Task SaveAsync(Laptop laptop)
    {
        await _repository.SaveAsync(laptop);
    }
}
