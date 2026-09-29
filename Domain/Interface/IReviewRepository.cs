using Domain.Models;

namespace Domain.Interface;

public interface IReviewRepository
{
    Task<List<Review>> GetReviewsByEventIdAsync(int eventId);
    Task<Review?> GetReviewByIdAsync(int id);
    Task<bool> AddReviewAsync(Review review);
    Task<bool> ExistsAsync(int eventId, int attendeeId);
}