namespace Infrastructure.Configuration;

public class CosmosDbConfiguration
{
    public required string AccountEndpoint { get; set; }
    public required string PrimaryKey { get; set; }
    public required string DatabaseName { get; set; }
}