namespace Domain.Configurations.Repositories;

public interface IRepository
{
    Task<T?> GetAsync<T>(string itemId)
        where T : AggregateRoot;

    Task SaveAsync<T>(T entity)
        where T : AggregateRoot;
}
