using Domain;
using Domain.Configurations.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Configurations.Repositories;

internal class MongoDbCollectionProvider
    : IMongoDbCollectionProvider
{
    private readonly IOptions<DatabaseSettings> _settings;

    public MongoDbCollectionProvider(
        IOptions<DatabaseSettings> settings)
    {
        _settings = settings;
    }
    public IMongoCollection<T> GetDbColection<T>()
        where T : AggregateRoot
    {
        var mogoClient = new MongoClient(_settings.Value.ConnectionString);
        var database = mogoClient.GetDatabase(_settings.Value.DatabaseName);

        return database.GetCollection<T>(typeof(T).Name);
    }
}
