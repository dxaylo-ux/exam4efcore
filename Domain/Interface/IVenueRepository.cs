using Domain.Models;

namespace Domain.Interface;

public interface IVenueRepository
{
    Task<List<Venue>> GetAllVenueAsync();
    Task<Venue?> GetVenueByIdAsync(int id);
    Task<bool> AddVenueAsync(Venue venue);
    Task<bool> DeleteVenueAsync(int id);
    Task<bool> HasEventsVenueAsync(int venueId);
}