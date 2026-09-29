using Application.DTOs.Order;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<ApiResponse<OrderDto>> GetOrderByIdAsync(int id);
    Task<ApiResponse<List<OrderDto>>> GetOrdersByAttendeeIdAsync(int attendeeId);
    Task<ApiResponse<bool>> AddOrderAsync(OrderCreateDto order);
    Task<ApiResponse<bool>> UpdateOrderAsync(int id, OrderUpdateDto order);
}