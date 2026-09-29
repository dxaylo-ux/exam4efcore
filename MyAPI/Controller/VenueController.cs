using Application.DTOs.Venue;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class VenueController(IVenueService venueService) : ControllerBase
{
    private IVenueService service = venueService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddVenueAsync(VenueCreateDto venue)
    {
        return await service.AddVenueAsync(venue);
    }


    [HttpGet]
    public async Task<ApiResponse<List<VenueDto>>> GetVenuesAsync()
    {
        return await service.GetAllVenueAsync();
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<VenueDto>> GetVenueByIdAsync(int id)
    {
        return await service.GetVenueByIdAsync(id);
    }


    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteVenueAsync(int id)
    {
        return await service.DeleteVenueAsync(id);
    }


    [HttpGet("{id:int}/has-events")]
    public async Task<ApiResponse<bool>> HasEventsVenueAsync(int id)
    {
        return await service.HasEventsVenueAsync(id);
    }
}