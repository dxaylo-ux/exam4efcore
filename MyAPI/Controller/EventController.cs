using Application.DTOs.Event;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class EventController(IEventService eventService) : ControllerBase
{
    private IEventService service = eventService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddEventAsync(EventCreateDto eventDto)
    {
        return await service.AddEventAsync(eventDto);
    }


    [HttpGet]
    public async Task<ApiResponse<List<EventDto>>> GetEventsAsync()
    {
        return await service.GetAllEventAsync();
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<EventDto>> GetEventByIdAsync(int id)
    {
        return await service.GetEventByIdAsync(id);
    }


    [HttpGet("{id:int}/details")]
    public async Task<ApiResponse<EventDto>> GetEventDetailsAsync(int id)
    {
        return await service.GetEventDetailsAsync(id);
    }


    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateEventAsync(
        int id,
        EventUpdateDto eventDto)
    {
        return await service.UpdateEventAsync(id, eventDto);
    }


    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteEventAsync(int id)
    {
        return await service.DeleteEventAsync(id);
    }


    [HttpGet("{id:int}/exists")]
    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        return await service.ExistsAsync(id);
    }
}