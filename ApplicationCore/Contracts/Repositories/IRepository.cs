namespace ApplicationCore.Contracts.Repositories;

public interface IRepository<T> where T : class
{
    Task<T> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
}