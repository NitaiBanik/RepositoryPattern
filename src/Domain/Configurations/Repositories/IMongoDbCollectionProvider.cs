using MongoDB.Driver;

namespace Domain.Configurations.Repositories;

public interface IMongoDbCollectionProvider
{
    IMongoCollection<T> GetDbColection<T>()
        where T : AggregateRoot;
}
