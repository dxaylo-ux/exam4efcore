using Domain.Models;

namespace Domain.Interface;
public interface IAttendeeProfileRepository
{
    Task<AttendeeProfile?> GetByAttendeeProfileIdAsync(int attendeeId);
    Task<bool> AddAttendeeProfileAsync(AttendeeProfile profile);
    Task<bool> UpdateAttendeeProfileAsync(AttendeeProfile profile);
}   