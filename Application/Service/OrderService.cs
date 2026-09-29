using System.Net;
using Application.DTOs.Order;
using Domain.Interface;
using Domain.Models;
using Application.Interfaces;

namespace Application.Service;

public class OrderService(IOrderRepository repository) : IOrderService
{
    private IOrderRepository service = repository;

    public async Task<ApiResponse<OrderDto>> GetOrderByIdAsync(int id)
    {
        var order = await service.GetOrderByIdAsync(id);

        if (order == null)
        {
            return new ApiResponse<OrderDto>(HttpStatusCode.NotFound,"Order not found",null!);
        }

        var result = new OrderDto
        {
            Id = order.Id,
            AttendeeId = order.AttendeeId,
            CreatedAt = order.CreatedAt,
            PaidAt = order.PaidAt,
            TotalAmount = order.TotalAmount,
            Status = order.Status
        };

        return new ApiResponse<OrderDto>(HttpStatusCode.OK,"Order by id",result);
    }

    public async Task<ApiResponse<List<OrderDto>>> GetOrdersByAttendeeIdAsync(int attendeeId)
    {
        var orders = await service.GetOrdersByAttendeeIdAsync(attendeeId);
        var result = orders.Select(x => new OrderDto
        {
            Id = x.Id,
            AttendeeId = x.AttendeeId,
            CreatedAt = x.CreatedAt,
            PaidAt = x.PaidAt,
            TotalAmount = x.TotalAmount,
            Status = x.Status

        }).ToList();

        return new ApiResponse<List<OrderDto>>(HttpStatusCode.OK,"Attendee orders",result);
    }

    public async Task<ApiResponse<bool>> AddOrderAsync(OrderCreateDto order)
    {
        var ord = new Order
        {
            AttendeeId = order.AttendeeId,
            CreatedAt = DateTime.UtcNow,
            TotalAmount = 0
        };

        var result = await service.AddOrderAsync(ord);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Order added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Order not added",result);
    }

    public async Task<ApiResponse<bool>> UpdateOrderAsync(int id,OrderUpdateDto order)
    {
        var ord = new Order
        {
            Id = id,
            TotalAmount = order.TotalAmount,
            PaidAt = order.PaidAt,
            Status = order.Status
        };

        var result = await service.UpdateOrderAsync(ord);
        return result
        
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Order updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Order cannot be updated",result);
    }
}