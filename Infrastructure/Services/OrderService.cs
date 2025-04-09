using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IMemoryCache cache;

    public OrderService(IOrderRepository orderRepository, IMemoryCache cache)
    {
        this.orderRepository = orderRepository;
        this.cache = cache;
    }
    
    public async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        if (cache.TryGetValue("AllOrders", out IEnumerable<Order> orders))
        {
            return orders;
        }
        
        orders = await orderRepository.GetAllAsync();
        cache.Set("AllOrders", orders, TimeSpan.FromSeconds(60));
        return orders;
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