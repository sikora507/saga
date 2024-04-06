using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Db;

public class SagaPatternDbContext : DbContext
{
    private readonly string _accountEndpoint;
    private readonly string _primaryKey;
    private readonly string _databaseName;

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
}