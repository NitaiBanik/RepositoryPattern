namespace Domain.Configurations;
using Microsoft.AspNetCore.JsonPatch;

public interface IRepository
{
    Task<IReadOnlyList<T>> GetAllAsync<T>()
        where T : AggregateRoot;

    Task<T?> GetAsync<T>(string itemId)
        where T : AggregateRoot;

    Task SaveAsync<T>(T entity)
        where T : AggregateRoot;

    Task UpdateAsync<T>(T entity)
        where T : AggregateRoot;

    Task ModifyAsync<T>(string id, JsonPatchDocument<T> entity)
        where T : AggregateRoot;

    Task DeleteAsync<T>(string id)
        where T : AggregateRoot;
}
