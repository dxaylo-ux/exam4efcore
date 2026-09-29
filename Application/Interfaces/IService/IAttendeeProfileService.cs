using Application.DTOs.AttendeeProfiles;

public interface IAttendeeProfileService
{
    Task<ApiResponse<AttendeeProfileDto?>> GetByAttendeeProfileIdAsync(int attendeeId);
    Task<ApiResponse<bool>> AddAttendeeProfileAsync(CreateAttendeeProfileDto dto);
    Task<ApiResponse<bool>> UpdateAttendeeProfileAsync(int attendeeId,UpdateAttendeeProfileDto dto);
}