using System.Net;
using Application.DTOs.Venue;
using Application.Interfaces;
using Domain.Interface;
using Domain.Models;

namespace Application.Service;

public class VenueService(IVenueRepository repository) : IVenueService
{
    private IVenueRepository service = repository;

    public async Task<ApiResponse<List<VenueDto>>> GetAllVenueAsync()
    {
        var venues = await service.GetAllVenueAsync();
        var result = venues.Select(x => new VenueDto
        {
            Id = x.Id,
            Name = x.Name,
            Address = x.Address,
            City = x.City,
            Capacity = x.Capacity

        }).ToList();

        return new ApiResponse<List<VenueDto>>(HttpStatusCode.OK,"List of venues",result);
    }

    public async Task<ApiResponse<VenueDto>> GetVenueByIdAsync(int id)
    {
        var venue = await service.GetVenueByIdAsync(id);

        if (venue == null)
        {
            return new ApiResponse<VenueDto>(HttpStatusCode.NotFound,"Venue not found",null!);
        }

        var result = new VenueDto
        {
            Id = venue.Id,
            Name = venue.Name,
            Address = venue.Address,
            City = venue.City,
            Capacity = venue.Capacity
        };

        return new ApiResponse<VenueDto>(HttpStatusCode.OK,"Venue by id",result);
    }

    public async Task<ApiResponse<bool>> AddVenueAsync(VenueCreateDto venue)
    {
        var ven = new Venue
        {
            Name = venue.Name,
            Address = venue.Address,
            City = venue.City,
            Capacity = venue.Capacity
        };

        var result = await service.AddVenueAsync(ven);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Venue added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Venue not added",result);
    }

    public async Task<ApiResponse<bool>> DeleteVenueAsync(int id)
    {
        var hasEvents = await service.HasEventsVenueAsync(id);

        if (hasEvents)
        {
            return new ApiResponse<bool>(HttpStatusCode.BadRequest,"Venue has events and cannot be deleted",false);
        }

        var result = await service.DeleteVenueAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Venue deleted",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Venue cannot be deleted",result);
    }

    public async Task<ApiResponse<bool>> HasEventsVenueAsync(int venueId)
    {
        var result = await service.HasEventsVenueAsync(venueId);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Venue has events",result)
        : new ApiResponse<bool>(HttpStatusCode.NotFound,"Venue has no events",result);
    }
}