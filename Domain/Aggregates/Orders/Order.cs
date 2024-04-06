using Domain.Aggregates.Products;
using Domain.Enums;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Domain.Aggregates.Orders;

public class Order : Entity, IAggregateRoot
{
    public OrderStatus Status { get; private set; }
    private readonly List<OrderItem> _items = [];
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public Order()
    {
        Status = OrderStatus.Pending;
    }

    public void AddItem(Product product, int quantity)
    {
        var item = _items.FirstOrDefault(i => i.ProductId == product.Id);
        if (item is null)
        {
            _items.Add(new OrderItem(product.Id, product.Name, quantity, product.Price));
        }
        else
        {
            // Update quantity of the existing item
            item.AddQuantity(quantity);
        }
    }
}