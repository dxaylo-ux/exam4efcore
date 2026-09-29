using Domain.Models;

namespace Domain.Interface;

public interface IOrderRepository
{
    Task<Order?> GetOrderByIdAsync(int id);
    Task<List<Order>> GetOrdersByAttendeeIdAsync(int attendeeId);
    Task<bool> AddOrderAsync(Order order);
    Task<bool> UpdateOrderAsync(Order order);
    Task SaveChangesAsync();
}