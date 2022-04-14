using Domain.Configurations;
using Domain.Laptops;
using System.Reflection;

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

    public async Task UpdateAsync(Laptop laptop)
    {
        await _repository.UpdateAsync(laptop);
    }
    public async Task ModifyAsync(string id, UpdatedLaptop updatedlaptop)
    {
        var laptop = await _repository.GetAsync<Laptop>(id);
        if (laptop == null)
        {
            throw new InvalidOperationException(
                $"Laptop not found with id: {id}");
        }

        foreach (PropertyInfo prop in updatedlaptop.GetType().GetProperties())
        {
            if (prop.GetValue(updatedlaptop) != null)
            {
                laptop.GetType().GetProperty(prop.Name)?.SetValue(laptop, prop.GetValue(updatedlaptop));
            }
        }

        await _repository.UpdateAsync(laptop);
    }
    
    public async Task DeleteAsync(string id)
    {
        await _repository.DeleteAsync<Laptop>(id);
    }
}
