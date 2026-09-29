using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class AttendeeRepository(AppDbContext appDbContext) : IAttendeeRepository
{
    private AppDbContext context = appDbContext;

    public async Task<List<Attendee>> GetAllAttendeeAsync()
    {
        return await context.Attendees
        .Include(x => x.Profile)
        .ToListAsync();
    }

    public async Task<Attendee?> GetAttendeeByIdAsync(int id)
    {
        return await context.Attendees
        .Include(x => x.Profile)
        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddAttendeeAsync(Attendee attendee)
    {
        context.Attendees.Add(attendee);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateAttendeeAsync(Attendee attendee)
    {
        var att = await context.Attendees.SingleOrDefaultAsync(x => x.Id == attendee.Id);

        if (att != null)
        {
            att.FullName = attendee.FullName;
            att.Email = attendee.Email;
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteAttendeeAsync(int id)
    {
        var att = await context.Attendees.FirstOrDefaultAsync(x => x.Id == id);

        if (att != null)
        {
            context.Attendees.Remove(att);
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Attendees.AnyAsync(x => x.Id == id);
    }
}