using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class EventRepository(AppDbContext appDbContext) : IEventRepository
{
    private AppDbContext context = appDbContext;

    public async Task<List<Event>> GetAllEventAsync()
    {
        return await context.Events.Where(x => !x.IsDeleted).ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        return await context.Events.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<Event?> GetEventDetailsAsync(int id)
    {
        return await context.Events
        .Include(x => x.Venue)
        .Include(x => x.Organizer)
        .Include(x => x.Categories)
        .Include(x => x.TicketTypes)
        .Include(x => x.Reviews)
        .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task<bool> AddEventAsync(Event eventEntity)
    {
        context.Events.Add(eventEntity);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateEventAsync(Event eventEntity)
    {
        var ev = await context.Events.SingleOrDefaultAsync(x => x.Id == eventEntity.Id);

        if (ev != null)
        {
            ev.Title = eventEntity.Title;
            ev.Description = eventEntity.Description;
            ev.StartDate = eventEntity.StartDate;
            ev.EndDate = eventEntity.EndDate;
            ev.Status = eventEntity.Status;
            ev.VenueId = eventEntity.VenueId;
            ev.OrganizerId = eventEntity.OrganizerId;
            ev.UpdatedAt = eventEntity.UpdatedAt;
            ev.IsDeleted = eventEntity.IsDeleted;
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        var ev = await context.Events.FirstOrDefaultAsync(x => x.Id == id);

        if (ev != null)
        {
            ev.IsDeleted = true;
            ev.UpdatedAt = DateTime.UtcNow;
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Events.AnyAsync(x => x.Id == id && !x.IsDeleted);
    }
}