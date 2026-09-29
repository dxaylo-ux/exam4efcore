using Application.DTOs.TicketType;

namespace Application.Interfaces;

public interface ITicketTypeService
{
    Task<ApiResponse<List<TicketTypeDto>>> GetAllTicketTypeAsync();
    Task<ApiResponse<TicketTypeDto>> GetTicketTypeByIdAsync(int id);
    Task<ApiResponse<bool>> AddTicketTypeAsync(TicketTypeCreateDto ticketType);
    Task<ApiResponse<bool>> UpdateTicketTypeAsync(int id,TicketTypeUpdateDto ticketType);
    Task<ApiResponse<bool>> DeleteTicketTypeAsync(int id);
}