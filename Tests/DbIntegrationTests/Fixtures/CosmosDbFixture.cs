using Infrastructure;
using Infrastructure.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbIntegrationTests.Fixtures;

[Collection(nameof(CosmosDbCollection))]
public class CosmosDbFixture : IAsyncLifetime
{
    public SagaPatternDbContext Context { get; }
    
    public CosmosDbFixture()
    {
        // Configuration
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.test.json") // Ensure this file exists and is copied to output
            .Build();

        // Setup DI
        var services = new ServiceCollection();
        services.AddInfrastructureServices(configuration); // Assuming you have this extension method
        var serviceProvider = services.BuildServiceProvider();

        // Get the DbContext
        Context = serviceProvider.GetRequiredService<SagaPatternDbContext>();

    }

    public async Task InitializeAsync()
    {
        await Context.Database.EnsureDeletedAsync();
        await Context.Database.EnsureCreatedAsync();
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
}