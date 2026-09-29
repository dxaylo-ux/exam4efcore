using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class VenueRepository(AppDbContext appDbContext) : IVenueRepository
{
  private AppDbContext context = appDbContext;

    public async Task<bool> AddVenueAsync(Venue venue)
    {
        context.Venues.Add(venue);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteVenueAsync(int id)
    {
        var venue = await context.Venues.FirstOrDefaultAsync(v => v.Id == id);

        if (venue != null)
        {
           context.Venues.Remove(venue); 
        }
       
       var result = await context.SaveChangesAsync();
       return result > 0;
    }

    public async Task<List<Venue>> GetAllVenueAsync()
    {
        return await context.Venues
        .Include(v => v.Events)
        .ToListAsync();
    }

    public async Task<Venue?> GetVenueByIdAsync(int id)
    {
        return await context.Venues
        .Include(v => v.Events)
        .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<bool> HasEventsVenueAsync(int venueId)
    {
       return await context.Events.AnyAsync(x => x.VenueId == venueId);
    }
}