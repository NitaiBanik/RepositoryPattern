using Domain.Laptops;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddSingleton<ILaptopRepository, LaptopRepository>();

        return services;
    }
}
