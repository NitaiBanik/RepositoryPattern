using Domain.Configurations.Repositories;
using Infrastructure.Configurations.Repositories;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddTransient<IMongoDbCollectionProvider, MongoDbCollectionProvider>();
        services.AddTransient<IRepository, Repository>();
        
        services.AddRepositories();

        return services;
    }

}