using API.ViewModels;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;

    public OrderController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> SaveNewOrder([FromBody] OrderViewModel orderViewModel)
    {
        var order = new Order
        {
            OrderDate = orderViewModel.OrderDate,
            CustomerId = orderViewModel.CustomerId,
            CustomerName = orderViewModel.CustomerName,
            PaymentMethodId = orderViewModel.PaymentMethodId,
            PaymentName = orderViewModel.PaymentName,
            ShippingAddress = orderViewModel.ShippingAddress,
            ShippingMethod = orderViewModel.ShippingMethod,
            BillAmount = orderViewModel.BillAmount,
            OrderStatus = orderViewModel.OrderStatus
        };
        
        await orderService.SaveNewOrderAsync(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, order);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByCustomerId(int id)
    {
        var orders = await orderService.GetOrderByCustomerIdAsync(id);
        return Ok(orders);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await orderService.DeleteOrderAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderViewModel orderViewModel)
    {
        var order = new Order
        {
            Id = id,
            OrderDate = orderViewModel.OrderDate,
            CustomerId = orderViewModel.CustomerId,
            CustomerName = orderViewModel.CustomerName,
            PaymentMethodId = orderViewModel.PaymentMethodId,
            PaymentName = orderViewModel.PaymentName,
            ShippingAddress = orderViewModel.ShippingAddress,
            ShippingMethod = orderViewModel.ShippingMethod,
            BillAmount = orderViewModel.BillAmount,
            OrderStatus = orderViewModel.OrderStatus
        };
        
        await orderService.UpdateOrderAsync(order);
        return NoContent();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await orderService.GetOrderByIdAsync(id);
        return Ok(order);
    }
}