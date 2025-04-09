using API.ViewModels;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService orderService;
    private readonly IMapper mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        this.orderService = orderService;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await orderService.GetAllOrdersAsync();
        var result = mapper.Map<IEnumerable<OrderResponseModel>>(orders);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> SaveNewOrder([FromBody] OrderRequestModel orderRequestModel)
    {
        var order = await orderService.SaveNewOrderAsync(mapper.Map<Order>(orderRequestModel));
        var response = mapper.Map<OrderResponseModel>(order);
        return CreatedAtAction(nameof(GetOrderById), new { id = response.Id }, response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderByCustomerId(int id)
    {
        var orders = await orderService.GetOrderByCustomerIdAsync(id);
        var result = mapper.Map<IEnumerable<OrderResponseModel>>(orders);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await orderService.DeleteOrderAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderRequestModel orderRequestModel)
    {
        var order = mapper.Map<Order>(orderRequestModel);
        order.Id = id;
        await orderService.UpdateOrderAsync(order);
        return NoContent();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await orderService.GetOrderByIdAsync(id);
        var result = mapper.Map<OrderResponseModel>(order);
        return Ok(result);
    }
}