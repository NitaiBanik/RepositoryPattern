using Domain;
using Domain.Configurations.Repositories;
using MongoDB.Driver;

namespace Infrastructure.Configurations.Repositories;

public class Repository
    : IRepository
{
    private readonly IMongoDbCollectionProvider _mongoDbCollectionProvider;

    public Repository(
        IMongoDbCollectionProvider mongoDbCollectionProvider)
    {
        _mongoDbCollectionProvider = mongoDbCollectionProvider;
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
}
