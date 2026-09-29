using Application.DTOs.AttendeeProfiles;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class AttendeeProfileController(
    IAttendeeProfileService attendeeProfileService) : ControllerBase
{
    private IAttendeeProfileService service = attendeeProfileService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddAttendeeProfileAsync(CreateAttendeeProfileDto profile)
    {
        return await service.AddAttendeeProfileAsync(profile);
    }


    [HttpGet("{attendeeId:int}")]
    public async Task<ApiResponse<AttendeeProfileDto>> GetByAttendeeProfileIdAsync(int attendeeId)
    {
        return await service.GetByAttendeeProfileIdAsync(attendeeId);
    }


    [HttpPut("{attendeeId:int}")]
    public async Task<ApiResponse<bool>> UpdateAttendeeProfileAsync(int attendeeId,UpdateAttendeeProfileDto profile)
    {
        return await service.UpdateAttendeeProfileAsync(attendeeId, profile);
    }
}