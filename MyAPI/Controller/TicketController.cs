using Application.DTOs.Ticket;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class TicketController(ITicketService ticketService) : ControllerBase
{
    private ITicketService service = ticketService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddTicketAsync(TicketCreateDto ticket)
    {
        return await service.AddTicketAsync(ticket);
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<TicketDto>> GetTicketByIdAsync(int id)
    {
        return await service.GetTicketByIdAsync(id);
    }


    [HttpGet("code/{code:guid}")]
    public async Task<ApiResponse<TicketDto>> GetTicketByCodeAsync(Guid code)
    {
        return await service.GetTicketByCodeAsync(code);
    }


    [HttpGet("attendee/{attendeeId:int}")]
    public async Task<ApiResponse<List<TicketDto>>> GetTicketsByAttendeeIdAsync(int attendeeId)
    {
        return await service.GetTicketsByAttendeeIdAsync(attendeeId);
    }


    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateTicketAsync(
        int id,
        TicketUpdateDto ticket)
    {
        return await service.UpdateTicketAsync(id, ticket);
    }
}