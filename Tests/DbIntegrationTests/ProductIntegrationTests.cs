using DbIntegrationTests.Fixtures;
using Domain.Aggregates.Products;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Xunit.Priority;

namespace DbIntegrationTests;

[Collection(nameof(CosmosDbCollection))]
public class ProductIntegrationTests : IClassFixture<ProductIntegrationTestsData>
{
    private readonly ProductIntegrationTestsData _data;
    
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductIntegrationTests(CosmosDbFixture fixture, ProductIntegrationTestsData data)
    {
        _data = data;
        _productRepository = new ProductRepository(fixture.Context);
        _unitOfWork = new UnitOfWork(fixture.Context);
    }
    
    [Fact, Priority(1)]
    public async Task CanAddProduct()
    {
        // Arrange
        var product = new Product("Product 1", 100, 10);
        _data.ProductId = product.Id;
        
        // Act
        await _productRepository.AddAsync(product);
        var numEntitiesWritten = await _unitOfWork.SaveChangesAsync();
        
        // Assert
        Assert.Equal(1, numEntitiesWritten);
    }
    
    [Fact, Priority(2)]
    public async Task CanReadProduct()
    {
        // Arrange
        // Act
        var product = await _productRepository.GetByIdAsync(_data.ProductId);
        
        // Assert
        Assert.Equal(_data.ProductId, product.Id);
    }
}

public class ProductIntegrationTestsData
{
    public Guid ProductId { get; set; }
}