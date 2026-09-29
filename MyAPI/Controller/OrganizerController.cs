using Application.DTOs.Organizer;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class OrganizerController(IOrganizerService organizerService) : ControllerBase
{
    private IOrganizerService service = organizerService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrganizerAsync(
        OrganizerCreateDto organizer)
    {
        return await service.AddOrganizerAsync(organizer);
    }


    [HttpGet]
    public async Task<ApiResponse<List<OrganizerDto>>> GetOrganizersAsync()
    {
        return await service.GetAllOrganizerAsync();
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<OrganizerDto>> GetOrganizerByIdAsync(int id)
    {
        return await service.GetOrganizerByIdAsync(id);
    }


    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateOrganizerAsync(
        int id,
        OrganizerUpdateDto organizer)
    {
        return await service.UpdateOrganizerAsync(id, organizer);
    }


    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteOrganizerAsync(int id)
    {
        return await service.DeleteOrganizerAsync(id);
    }


    [HttpGet("{id:int}/exists")]
    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        return await service.ExistsAsync(id);
    }
}