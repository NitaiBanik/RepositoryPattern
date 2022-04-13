using Domain.Configurations.Repositories;
using Infrastructure.Configurations.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IMongoDbCollectionProvider, MongoDbCollectionProvider>();
        services.AddSingleton<IRepository, Repository>();

        return services;
    }

}