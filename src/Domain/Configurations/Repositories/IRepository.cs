namespace Domain.Configurations.Repositories;

public interface IRepository
{
    Task<IReadOnlyList<T>> GetAllAsync<T>()
        where T : AggregateRoot;
    
    Task<T?> GetAsync<T>(string itemId)
        where T : AggregateRoot;

    Task SaveAsync<T>(T entity)
        where T : AggregateRoot;
}
