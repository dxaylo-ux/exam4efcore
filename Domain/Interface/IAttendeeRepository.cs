using Domain.Models;

namespace Domain.Interface;

public interface IAttendeeRepository
{
    Task<List<Attendee>> GetAllAttendeeAsync();
    Task<Attendee?> GetAttendeeByIdAsync(int id);
    Task<bool> AddAttendeeAsync(Attendee attendee);
    Task<bool> UpdateAttendeeAsync(Attendee attendee);
    Task<bool> DeleteAttendeeAsync(int id);
    Task<bool> ExistsAsync(int id);
}