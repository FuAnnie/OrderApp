using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly OrderDbContext orderDbContext;
    
    public BaseRepository(OrderDbContext orderDbContext)
    {
        this.orderDbContext = orderDbContext;
    }
    
    public async Task<int> InsertAsync(T entity)
    {
        await orderDbContext.Set<T>().AddAsync(entity);
        return await orderDbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        orderDbContext.Set<T>().Entry(entity).State = EntityState.Modified;
        return await orderDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(int id)
    {
        var item = await GetByIdAsync(id);
        if (item != null)
        {
            orderDbContext.Set<T>().Remove(item);
        }
        return await orderDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await orderDbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await orderDbContext.Set<T>().FindAsync(id);
    }
}