using Domain;
using Domain.Configurations;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;

namespace Infrastructure.Configurations;

public class Repository
    : IRepository
{
    private readonly IMongoDbCollectionProvider _mongoDbCollectionProvider;

    public Repository(
        IMongoDbCollectionProvider mongoDbCollectionProvider)
    {
        _mongoDbCollectionProvider = mongoDbCollectionProvider;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync<T>()
        where T : AggregateRoot
    {
        var collection = _mongoDbCollectionProvider.GetDbCollection<T>();

        return await collection
            .Find(e => true)
            .ToListAsync();
    }

    public async Task<T?> GetAsync<T>(string itemId)
        where T : AggregateRoot
    {
        var collection = _mongoDbCollectionProvider.GetDbCollection<T>();

        return await collection
            .Find(e => e.ItemId == itemId)
            .SingleOrDefaultAsync();
    }

    public async Task SaveAsync<T>(T entity)
        where T : AggregateRoot
    {
        var collection = _mongoDbCollectionProvider
            .GetDbCollection<T>();

        await collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync<T>(T entity)
        where T : AggregateRoot
    {
        var collection = _mongoDbCollectionProvider
            .GetDbCollection<T>();

        await collection.ReplaceOneAsync(
            e => e.ItemId == entity.ItemId, entity);
    }

    public async Task ModifyAsync<T>(string id, JsonPatchDocument<T> entity)
        where T : AggregateRoot
    {
        var collection = _mongoDbCollectionProvider
            .GetDbCollection<T>();

        UpdateDefinition<T> update = null;

        foreach (var x in entity.Operations)
        {
            if (update == null)
            {
                var builder = Builders<T>.Update;
                update = builder.Set(x.path, x.value);
            }
            else
            {
                update = update.Set(x.path, x.value);
            }
        }

        await collection.UpdateOneAsync(
            e => e.ItemId == id, update);
    }

    public async Task DeleteAsync<T>(string id)
        where T : AggregateRoot
    {
        var collection = _mongoDbCollectionProvider
             .GetDbCollection<T>();

        await collection.DeleteOneAsync(
            e => e.ItemId == id);
    }
}
