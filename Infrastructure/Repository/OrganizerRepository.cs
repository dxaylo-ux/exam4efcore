using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace Infrastructure.Repository;

public class OrganizerRepository(AppDbContext appDbContext) : IOrganizerRepository
{
    private AppDbContext context = appDbContext;

    public async Task<bool> AddOrganizerAsync(Organizer organizer)
    {
        context.Organizers.Add(organizer);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteOrganizerAsync(int id)
    {
        var org = await context.Organizers.SingleOrDefaultAsync(x => x.Id == id);

        if(org != null)
        {
            context.Organizers.Remove(org);
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Organizers.AnyAsync(x => x.Id == id);
    }

    public async Task<List<Organizer>> GetAllOrganizerAsync()
    {
        return await context.Organizers
        .Include(x => x.Events)
        .ToListAsync();
    }

    public async Task<Organizer?> GetOrganizerByIdAsync(int id)
    {
        return await context.Organizers
        .Include(x => x.Events)
        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> UpdateOrganizerAsync(Organizer organizer)
    {
        var org = await context.Organizers.SingleOrDefaultAsync(x => x.Id == organizer.Id);

        if (org != null)
        {
            org.CompanyName = organizer.CompanyName;
            org.ContactEmail = organizer.ContactEmail;
            org.Phone = organizer.Phone;
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }
}