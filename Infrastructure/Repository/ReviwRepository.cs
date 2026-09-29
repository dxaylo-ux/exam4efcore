using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class ReviewRepository(AppDbContext appDbContext) : IReviewRepository
{
    private AppDbContext context = appDbContext;

    public async Task<List<Review>> GetReviewsByEventIdAsync(int eventId)
    {
        return await context.Reviews.Where(x => x.EventId == eventId)
        .Include(x => x.Attendee)
        .Include(x => x.Event)
        .ToListAsync();
    }

    public async Task<Review?> GetReviewByIdAsync(int id)
    {
        return await context.Reviews
        .Include(x => x.Attendee)
        .Include(x => x.Event)
        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddReviewAsync(Review review)
    {
        context.Reviews.Add(review);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ExistsAsync(int eventId, int attendeeId)
    {
        return await context.Reviews
        .AnyAsync(x => x.EventId == eventId && x.AttendeeId == attendeeId);
    }
}