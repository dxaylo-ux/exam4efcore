using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repository;

public class TicketTypeRepository(AppDbContext appDbContext) : ITicketTypeRepository
{
    private AppDbContext context = appDbContext;

    public async Task<List<TicketType>> GetAllTicketTypeAsync()
    {
        return await context.TicketTypes
            .Include(x => x.Event)
            .ToListAsync();
    }

    public async Task<TicketType?> GetTicketTypeByIdAsync(int id)
    {
        return await context.TicketTypes
            .Include(x => x.Event)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<TicketType>> GetTicketTypesByEventIdAsync(int eventId)
    {
        return await context.TicketTypes
            .Where(x => x.EventId == eventId)
            .ToListAsync();
    }

    public async Task<bool> AddTicketTypeAsync(TicketType ticketType)
    {
        context.TicketTypes.Add(ticketType);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateTicketTypeAsync(TicketType ticketType)
    {
        var tkt = await context.TicketTypes.SingleOrDefaultAsync(x => x.Id == ticketType.Id);

         if (tkt != null)
        {
           tkt.EventId = ticketType.EventId;
           tkt.Name = ticketType.Name;
           tkt.Price = ticketType.Price;
           tkt.Quantity = ticketType.Quantity;
           tkt.SoldCount = ticketType.SoldCount;
        }   

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteTicketTypeAsync(int id)
    {
        var ticketType = await context.TicketTypes.SingleOrDefaultAsync(x => x.Id == id);

        if (ticketType != null)
        {
            context.TicketTypes.Remove(ticketType);
        }
        
        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}