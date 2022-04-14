using Domain.Laptops;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(
        this IServiceCollection services)
    {
        services.AddTransient<ILaptopRepository, LaptopRepository>();

        return services;
    }
}
