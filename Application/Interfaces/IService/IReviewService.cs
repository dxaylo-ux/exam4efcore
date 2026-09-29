using Application.DTOs.Review;
using Domain.Models;

namespace Application.Interfaces;

public interface IReviewService
{
    Task<ApiResponse<List<ReviewDto>>> GetReviewsByEventIdAsync(int eventId);
    Task<ApiResponse<ReviewDto?>> GetReviewByIdAsync(int id);
    Task<ApiResponse<bool>> AddReviewAsync(ReviewCreateDto review);
    Task<ApiResponse<bool>> ExistsAsync(int eventId, int attendeeId);
}