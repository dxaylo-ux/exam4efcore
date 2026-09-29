using System.Net;
using Application.DTOs.Event;
using Domain.Interface;
using Domain.Models;
using Application.Interfaces;

namespace Application.Service;

public class EventService(IEventRepository repository) : IEventService
{
    private IEventRepository service = repository;

    public async Task<ApiResponse<List<EventDto>>> GetAllEventAsync()
    {
        var events = await service.GetAllEventAsync();
        var result = events.Select(x => new EventDto
        {
            Id = x.Id,
            Title = x.Title,
            StartDate = x.StartDate,
            Status = x.Status
            
        }).ToList();

        return new ApiResponse<List<EventDto>>(HttpStatusCode.OK,"List of events",result);
    }

    public async Task<ApiResponse<EventDto>> GetEventByIdAsync(int id)
    {
        var eventEntity = await service.GetEventByIdAsync(id);

        if (eventEntity == null)
        {
            return new ApiResponse<EventDto>(HttpStatusCode.NotFound,"Event not found",null!);
        }

        var result = new EventDto
        {
            Id = eventEntity.Id,
            Title = eventEntity.Title,
            StartDate = eventEntity.StartDate,
            Status = eventEntity.Status
    
        };

        return new ApiResponse<EventDto>(HttpStatusCode.OK,"Event by id",result);
    }

    public async Task<ApiResponse<EventDto>> GetEventDetailsAsync(int id)
    {
        var eventEntity = await service.GetEventDetailsAsync(id);

        if (eventEntity == null)
        {
            return new ApiResponse<EventDto>(HttpStatusCode.NotFound,"Event not found",null!);
        }

        var result = new EventDto
        {
            Id = eventEntity.Id,
            Title = eventEntity.Title,
            StartDate = eventEntity.StartDate,
            Status = eventEntity.Status
        };

        return new ApiResponse<EventDto>(HttpStatusCode.OK,"Event details",result);
    }

    public async Task<ApiResponse<bool>> AddEventAsync(
        EventCreateDto eventDto)
    {
        var eventEntity = new Event
        {
            Title = eventDto.Title,
            Description = eventDto.Description,
            StartDate = eventDto.StartDate,
            EndDate = eventDto.EndDate,
            VenueId = eventDto.VenueId,
        };

        var result = await service.AddEventAsync(eventEntity);
        return result
        
        ? new ApiResponse<bool>(HttpStatusCode.OK,"Event added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Event not added",result);
    }

    public async Task<ApiResponse<bool>> UpdateEventAsync(int id,EventUpdateDto eventDto)
    {
        var eventEntity = new Event
        {
            Id = id,
            Title = eventDto.Title,
            Description = eventDto.Description,
            StartDate = eventDto.StartDate,
            EndDate = eventDto.EndDate,
            VenueId = eventDto.VenueId,
        };

        var result = await service.UpdateEventAsync(eventEntity);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Event updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Event cannot be updated",result);
    }

    public async Task<ApiResponse<bool>> DeleteEventAsync(int id)
    {
        var result = await service.DeleteEventAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Event deleted",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Event cannot be deleted",result);
    }

    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        var result = await service.ExistsAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Event exists",result)
        : new ApiResponse<bool>(HttpStatusCode.NotFound,"Event not found",result);
    }
}