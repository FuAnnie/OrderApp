using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext)
    {
    }

    public async Task<List<Order>> GetOrderByCustomerId(int id)
    {
        return await orderDbContext.Orders
            .Where(o => o.CustomerId == id)
            .ToListAsync();
    }
}