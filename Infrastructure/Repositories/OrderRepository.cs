using Domain.Aggregates.Orders;
using Domain.Interfaces.Repositories;
using Infrastructure.Db;

namespace Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(SagaPatternDbContext context) : base(context)
    {
    }
}