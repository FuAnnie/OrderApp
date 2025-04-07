using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<int> SaveNewOrderAsync(Order order);
    Task<List<Order>> GetOrderByCustomerIdAsync(int id);
    Task<int> DeleteOrderAsync(int id);
    Task<int> UpdateOrderAsync(Order order);
    Task<Order?> GetOrderByIdAsync(int id);
}