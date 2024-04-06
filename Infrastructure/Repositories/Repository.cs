using Domain.Interfaces;
using Infrastructure.Db;

namespace Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class, IAggregateRoot
{
    protected readonly SagaPatternDbContext Context;

    public Repository(SagaPatternDbContext context)
    {
        Context = context;
    }
    
    public async Task<T> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task AddAsync(T entity)
    {
        await Context.Set<T>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }
}