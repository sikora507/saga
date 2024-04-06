using Domain.Aggregates.Orders;
using Domain.Aggregates.Products;
using Infrastructure.Configuration;
using Infrastructure.Db.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Db;

public class SagaPatternDbContext : DbContext
{
    private readonly string _accountEndpoint;
    private readonly string _primaryKey;
    private readonly string _databaseName;
    
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;

    public SagaPatternDbContext(IOptions<CosmosDbConfiguration> cosmosOptions)
    {
        var cosmosSettings = cosmosOptions.Value;
        _accountEndpoint = cosmosSettings.AccountEndpoint;
        _primaryKey = cosmosSettings.PrimaryKey;
        _databaseName = cosmosSettings.DatabaseName;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos(_accountEndpoint, _primaryKey, _databaseName);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CosmosDbConfiguration).Assembly);
    }
}
