using Domain.Interfaces;

namespace Domain.Aggregates.Products;

public class Product : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }

    public Product(string name, decimal price, int stockQuantity)
    {
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void UpdateStock(int quantity)
    {
        StockQuantity += quantity;
    }
}