using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure.Configuration;
using Infrastructure.Db;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<CosmosDbConfiguration>(configuration.GetSection("CosmosDb"));
        services.AddDbContext<SagaPatternDbContext>();

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}