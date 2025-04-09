using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        this.orderRepository = orderRepository;
    }
    
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        return await orderRepository.GetAllAsync();
    }

    public async Task<Order> SaveNewOrderAsync(Order order)
    {
        return await orderRepository.InsertAsync(order);
    }

    public async Task<List<Order>> GetOrderByCustomerIdAsync(int id)
    {
        return await orderRepository.GetOrderByCustomerId(id);
    }

    public async Task<int> DeleteOrderAsync(int id)
    {
        return await orderRepository.DeleteAsync(id);
    }

    public async Task<int> UpdateOrderAsync(Order order)
    {
        return await orderRepository.UpdateAsync(order);
    }

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await orderRepository.GetByIdAsync(id);
    }
}