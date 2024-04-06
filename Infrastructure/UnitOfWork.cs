using Domain.Interfaces;
using Infrastructure.Db;

namespace Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly SagaPatternDbContext _context;

    public UnitOfWork(SagaPatternDbContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}