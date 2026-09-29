using Domain.Models;

namespace Domain.Interface;

public interface IEventRepository
{
    Task<List<Event>> GetAllEventAsync();
    Task<Event?> GetEventByIdAsync(int id);
    Task<Event?> GetEventDetailsAsync(int id);
    Task<bool> AddEventAsync(Event eventEntity);
    Task<bool> UpdateEventAsync(Event eventEntity);
    Task<bool> DeleteEventAsync(int id);
    Task<bool> ExistsAsync(int id);
}