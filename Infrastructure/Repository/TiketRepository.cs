using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class TicketRepository(AppDbContext appDbContext) : ITicketRepository
{
    private AppDbContext context = appDbContext;

    public async Task<Ticket?> GetTicketByIdAsync(int id)
    {
        return await context.Tickets
            .Include(x => x.Order)
            .Include(x => x.TicketType)
            .Include(x => x.Attendee)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Ticket?> GetTicketByCodeAsync(Guid code)
    {
        return await context.Tickets
        .Include(x => x.Order)
        .Include(x => x.TicketType)
        .Include(x => x.Attendee)
        .FirstOrDefaultAsync(x => x.Code == code);
    }

    public async Task<List<Ticket>> GetTicketsByAttendeeIdAsync(int attendeeId)
    {
        return await context.Tickets.Where(x => x.AttendeeId == attendeeId)
        .Include(x => x.Order)
        .Include(x => x.TicketType)
        .ToListAsync();
    }

    public async Task<bool> AddTicketAsync(Ticket ticket)
    {
        context.Tickets.Add(ticket);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateTicketAsync(Ticket ticket)
    {
    var tkt = await context.Tickets.SingleOrDefaultAsync(x => x.Id == ticket.Id);

    if (tkt != null)
    {
        tkt.OrderId = ticket.OrderId;
        tkt.TicketTypeId = ticket.TicketTypeId;
        tkt.AttendeeId = ticket.AttendeeId;
        tkt.Code = ticket.Code;
        tkt.Price = ticket.Price;
        tkt.PurchasedAt = ticket.PurchasedAt;
        tkt.IsCheckedIn = ticket.IsCheckedIn;
        tkt.CheckedInAt = ticket.CheckedInAt;
    }

    var res = await context.SaveChangesAsync();
    return res > 0;
    }
}