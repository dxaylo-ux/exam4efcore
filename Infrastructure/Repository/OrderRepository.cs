using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class OrderRepository(AppDbContext appDbContext) : IOrderRepository
{
    private AppDbContext context = appDbContext;

    public async Task<Order?> GetOrderByIdAsync(int id)
    {
        return await context.Orders
        .Include(x => x.Attendee)
        .Include(x => x.Tickets)
        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Order>> GetOrdersByAttendeeIdAsync(int attendeeId)
    {
        return await context.Orders
        .Where(x => x.AttendeeId == attendeeId)
        .Include(x => x.Tickets)
        .ToListAsync();
    }

    public async Task<bool> AddOrderAsync(Order order)
    {
        context.Orders.Add(order);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateOrderAsync(Order order)
    {
        var ord = await context.Orders.SingleOrDefaultAsync(x => x.Id == order.Id);

        if (ord != null)
        {
            ord.AttendeeId = order.AttendeeId;
            ord.PaidAt = order.PaidAt;
            ord.TotalAmount = order.TotalAmount;
            ord.Status = order.Status;
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}