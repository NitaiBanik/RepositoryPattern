using Domain.Configurations.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddSingleton<IMongoDbCollectionProvider, IMongoDbCollectionProvider>();

        return services;
    }

}