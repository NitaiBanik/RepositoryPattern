using Domain.Configurations;
using Domain.Laptops;
using Microsoft.AspNetCore.JsonPatch;
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

    public async Task ModifyAsync(string id, JsonPatchDocument<Laptop> updatedLaptop)
    {
        await _repository.ModifyAsync(id, updatedLaptop);
    }

    public async Task DeleteAsync(string id)
    {
        await _repository.DeleteAsync<Laptop>(id);
    }
}
