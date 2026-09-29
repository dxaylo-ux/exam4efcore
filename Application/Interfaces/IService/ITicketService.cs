using Application.DTOs.Ticket;

namespace Application.Interfaces;

public interface ITicketService
{
    Task<ApiResponse<TicketDto>> GetTicketByIdAsync(int id);
    Task<ApiResponse<TicketDto>> GetTicketByCodeAsync(Guid code);
    Task<ApiResponse<List<TicketDto>>> GetTicketsByAttendeeIdAsync(int attendeeId);
    Task<ApiResponse<bool>> AddTicketAsync(TicketCreateDto ticket);
    Task<ApiResponse<bool>> UpdateTicketAsync(int id, TicketUpdateDto ticket);
}