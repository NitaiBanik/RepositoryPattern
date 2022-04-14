using MongoDB.Driver;

namespace Domain.Configurations;

public interface IMongoDbCollectionProvider
{
    IMongoCollection<T> GetDbCollection<T>()
        where T : AggregateRoot;
}
