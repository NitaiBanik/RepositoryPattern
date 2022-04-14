namespace Domain.Laptops;

public interface ILaptopRepository
{
    Task<IReadOnlyList<Laptop>> GetAllAsync();
        
    Task <Laptop?>GetAsync(string id);
    
    Task SaveAsync(Laptop laptop);
    
    Task UpdateAsync(Laptop laptop);

    Task DeleteAsync(string id);
}
