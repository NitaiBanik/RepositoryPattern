namespace Domain.Laptops;

public interface ILaptopRepository
{
    Task <Laptop?>GetAsync(string id);
    
    Task SaveAsync(Laptop laptop);
}
