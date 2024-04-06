namespace Domain.Interfaces;

public interface IRepository<T> where T : class, IAggregateRoot
{
    Task<T> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}