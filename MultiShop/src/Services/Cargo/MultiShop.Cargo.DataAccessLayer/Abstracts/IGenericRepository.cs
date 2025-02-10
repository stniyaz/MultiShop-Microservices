namespace MultiShop.Cargo.DataAccessLayer.Abstracts;

public interface IGenericRepository<T> where T : class, new()
{
    Task CreateAsync(T entity);
    void Delete(T entity);
    Task SaveChangeAsync();
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
}
