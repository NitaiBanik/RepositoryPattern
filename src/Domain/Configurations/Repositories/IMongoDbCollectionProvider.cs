using MongoDB.Driver;

namespace Domain.Configurations.Repositories;

public interface IMongoDbCollectionProvider
{
    IMongoCollection<T> GetDbCollection<T>()
        where T : AggregateRoot;
}
