namespace Domain.ValueObjects;

public record OrderItem(
    Guid ProductId, 
    string ProductName, 
    int Quantity, 
    decimal Price)
{
    public OrderItem AddQuantity(int additionalQuantity) =>
        this with { Quantity = this.Quantity + additionalQuantity };
}