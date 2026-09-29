using Application.DTOs.Attendee;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class AttendeeController(IAttendeeService attendeeService) : ControllerBase
{
    private IAttendeeService service = attendeeService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddAttendeeAsync(
        AttendeeCreateDto attendee)
    {
        return await service.AddAttendeeAsync(attendee);
    }


    [HttpGet]
    public async Task<ApiResponse<List<AttendeeDto>>> GetAttendeesAsync()
    {
        return await service.GetAllAttendeeAsync();
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<AttendeeDto>> GetAttendeeByIdAsync(int id)
    {
        return await service.GetAttendeeByIdAsync(id);
    }


    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateAttendeeAsync(
        int id,
        UpdateAttendeeDto attendee)
    {
        return await service.UpdateAttendeeAsync(id, attendee);
    }


    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteAttendeeAsync(int id)
    {
        return await service.DeleteAttendeeAsync(id);
    }


    [HttpGet("{id:int}/exists")]
    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        return await service.ExistsAsync(id);
    }
}