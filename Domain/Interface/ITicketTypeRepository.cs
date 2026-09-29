using Domain.Models;

namespace Domain.Interface;

public interface ITicketTypeRepository
{
    Task<List<TicketType>> GetAllTicketTypeAsync();
    Task<TicketType?> GetTicketTypeByIdAsync(int id);
    Task<List<TicketType>> GetTicketTypesByEventIdAsync(int eventId);
    Task<bool> AddTicketTypeAsync(TicketType ticketType);
    Task<bool> UpdateTicketTypeAsync(TicketType ticketType);
    Task<bool> DeleteTicketTypeAsync(int id);
}