using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    public Task<List<Order>> GetOrderByCustomerId(int id);
}