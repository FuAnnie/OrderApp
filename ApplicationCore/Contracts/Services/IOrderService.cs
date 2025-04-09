using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> SaveNewOrderAsync(Order order);
    Task<List<Order>> GetOrderByCustomerIdAsync(int id);
    Task<int> DeleteOrderAsync(int id);
    Task<int> UpdateOrderAsync(Order order);
    Task<Order?> GetOrderByIdAsync(int id);
}