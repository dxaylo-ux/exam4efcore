using Application.DTOs.Attendee;

namespace Application.Interfaces;

public interface IAttendeeService
{
    Task<ApiResponse<List<AttendeeDto>>> GetAllAttendeeAsync();

    Task<ApiResponse<AttendeeDto>> GetAttendeeByIdAsync(int id);

    Task<ApiResponse<bool>> AddAttendeeAsync(AttendeeCreateDto attendee);

    Task<ApiResponse<bool>> UpdateAttendeeAsync(int id,UpdateAttendeeDto attendee);

    Task<ApiResponse<bool>> DeleteAttendeeAsync(int id);

    Task<ApiResponse<bool>> ExistsAsync(int id);
}