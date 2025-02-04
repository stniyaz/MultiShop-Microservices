using System.Linq.Expressions;

namespace MultiShop.Order.Application.Interfaces;

public interface IGenericRepository<T> where T : class, new()
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
