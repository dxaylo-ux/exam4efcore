using Application.DTOs.TicketType;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class TicketTypeController(ITicketTypeService ticketTypeService) : ControllerBase
{
    private ITicketTypeService service = ticketTypeService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddTicketTypeAsync(TicketTypeCreateDto ticketType)
    {
        return await service.AddTicketTypeAsync(ticketType);
    }


    [HttpGet]
    public async Task<ApiResponse<List<TicketTypeDto>>> GetTicketTypesAsync()
    {
        return await service.GetAllTicketTypeAsync();
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<TicketTypeDto>> GetTicketTypeByIdAsync(int id)
    {
        return await service.GetTicketTypeByIdAsync(id);
    }


    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateTicketTypeAsync(
        int id,
        TicketTypeUpdateDto ticketType)
    {
        return await service.UpdateTicketTypeAsync(id, ticketType);
    }


    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteTicketTypeAsync(int id)
    {
        return await service.DeleteTicketTypeAsync(id);
    }

}