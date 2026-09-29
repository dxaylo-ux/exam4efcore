using System.Net;
using Application.DTOs.AttendeeProfiles;
using Domain.Interface;
using Domain.Models;

namespace Application.Service;

public class AttendeeProfileService(IAttendeeProfileRepository repository) : IAttendeeProfileService
{
    private IAttendeeProfileRepository service = repository;

    public async Task<ApiResponse<bool>> AddAttendeeProfileAsync(CreateAttendeeProfileDto profile)
    {
        var prf = new AttendeeProfile
        {
            AttendeeId = profile.AttendeeId,
            DateOfBirth = profile.DateOfBirth,
            City = profile.City,
            Bio = profile.Bio
        };

        var result = await service.AddAttendeeProfileAsync(prf);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Attendee profile added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Attendee profile not added",result);
    }

    public async Task<ApiResponse<AttendeeProfileDto>> GetByAttendeeProfileIdAsync(int attendeeId)
    {
        var profile = await service.GetByAttendeeProfileIdAsync(attendeeId);

        if (profile == null)
        {
            return new ApiResponse<AttendeeProfileDto>(HttpStatusCode.NotFound,"Attendee profile not found",null!);
        }

        var result = new AttendeeProfileDto
        {
            AttendeeId = profile.AttendeeId,
            DateOfBirth = profile.DateOfBirth,
            City = profile.City,
            Bio = profile.Bio
        };

        return new ApiResponse<AttendeeProfileDto>(HttpStatusCode.OK,"Attendee profile by id",result);
    }

    public async Task<ApiResponse<bool>> UpdateAttendeeProfileAsync(int attendeeId,UpdateAttendeeProfileDto profile)
    {
        var prf = new AttendeeProfile
        {
            AttendeeId = attendeeId,
            DateOfBirth = profile.DateOfBirth,
            City = profile.City,
            Bio = profile.Bio
        };

        var result = await service.UpdateAttendeeProfileAsync(prf);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Attendee profile updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Attendee profile cannot be updated",result);
    }
    
}