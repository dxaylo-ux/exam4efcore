using Domain.Models;

namespace Domain.Interface;

public interface ITicketRepository
{
    Task<Ticket?> GetTicketByIdAsync(int id);
    Task<Ticket?> GetTicketByCodeAsync(Guid code);
    Task<List<Ticket>> GetTicketsByAttendeeIdAsync(int attendeeId);
    Task<bool> AddTicketAsync(Ticket ticket);
    Task<bool> UpdateTicketAsync(Ticket ticket);
}