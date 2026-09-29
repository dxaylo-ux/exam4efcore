using Domain.Models;

namespace Domain.Interface;

public interface IOrganizerRepository
{
    Task<List<Organizer>> GetAllOrganizerAsync();
    Task<Organizer?> GetOrganizerByIdAsync(int id);
    Task<bool> AddOrganizerAsync(Organizer organizer);
    Task<bool> UpdateOrganizerAsync(Organizer organizer);
    Task<bool> DeleteOrganizerAsync(int id);
    Task<bool> ExistsAsync(int id);
}