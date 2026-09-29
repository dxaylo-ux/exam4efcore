using Application.DTOs.Order;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class OrderController(IOrderService orderService) : ControllerBase
{
    private IOrderService service = orderService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrderAsync(OrderCreateDto order)
    {
        return await service.AddOrderAsync(order);
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<OrderDto>> GetOrderByIdAsync(int id)
    {
        return await service.GetOrderByIdAsync(id);
    }


    [HttpGet("attendee/{attendeeId:int}")]
    public async Task<ApiResponse<List<OrderDto>>> GetOrdersByAttendeeIdAsync(
        int attendeeId)
    {
        return await service.GetOrdersByAttendeeIdAsync(attendeeId);
    }


    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateOrderAsync(
        int id,
        OrderUpdateDto order)
    {
        return await service.UpdateOrderAsync(id, order);
    }
}