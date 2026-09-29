using Application.DTOs.Venue;

namespace Application.Interfaces;

public interface IVenueService
{
    Task<ApiResponse<List<VenueDto>>> GetAllVenueAsync();
    Task<ApiResponse<VenueDto>> GetVenueByIdAsync(int id);
    Task<ApiResponse<bool>> AddVenueAsync(VenueCreateDto venue);
    Task<ApiResponse<bool>> DeleteVenueAsync(int id);
    Task<ApiResponse<bool>> HasEventsVenueAsync(int venueId);
}