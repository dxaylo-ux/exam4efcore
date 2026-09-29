using Application.DTOs.Event;

namespace Application.Interfaces;

public interface IEventService
{
    Task<ApiResponse<List<EventDto>>> GetAllEventAsync();

    Task<ApiResponse<EventDto>> GetEventByIdAsync(int id);

    Task<ApiResponse<EventDto>> GetEventDetailsAsync(int id);

    Task<ApiResponse<bool>> AddEventAsync(EventCreateDto eventDto);

    Task<ApiResponse<bool>> UpdateEventAsync(int id, EventUpdateDto eventDto);

    Task<ApiResponse<bool>> DeleteEventAsync(int id);

    Task<ApiResponse<bool>> ExistsAsync(int id);
}