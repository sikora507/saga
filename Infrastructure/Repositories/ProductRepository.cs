using Domain.Aggregates.Products;
using Domain.Interfaces.Repositories;
using Infrastructure.Db;

namespace Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(SagaPatternDbContext context) : base(context)
    {
    }
}