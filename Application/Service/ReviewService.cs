using System.Net;
using Application.DTOs.Review;
using Domain.Interface;
using Domain.Models;
using Application.Interfaces;

namespace Application.Service;

public class ReviewService(IReviewRepository repository) : IReviewService
{
    private IReviewRepository service = repository;

    public async Task<ApiResponse<List<ReviewDto>>> GetReviewsByEventIdAsync(int eventId)
    {
        var reviews = await service.GetReviewsByEventIdAsync(eventId);
        var result = reviews.Select(x => new ReviewDto
        {
            Id = x.Id,
            EventId = x.EventId,
            AttendeeId = x.AttendeeId,
            Rating = x.Rating,
            Comment = x.Comment,
            CreatedAt = x.CreatedAt

        }).ToList();

        return new ApiResponse<List<ReviewDto>>(HttpStatusCode.OK,"Event reviews",result);
    }

    public async Task<ApiResponse<ReviewDto?>> GetReviewByIdAsync(int id)
    {
        var review = await service.GetReviewByIdAsync(id);

        if (review == null)
        {
            return new ApiResponse<ReviewDto?>(HttpStatusCode.NotFound,"Review not found",null);
        }

        var result = new ReviewDto
        {
            Id = review.Id,
            EventId = review.EventId,
            AttendeeId = review.AttendeeId,
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = review.CreatedAt
        };

        return new ApiResponse<ReviewDto?>(HttpStatusCode.OK,"Review by id",result);
    }

    public async Task<ApiResponse<bool>> AddReviewAsync(
        ReviewCreateDto review)
    {
        var rev = new Review
        {
            Rating = review.Rating,
            Comment = review.Comment,
            CreatedAt = DateTime.UtcNow
        };

        var result = await service.AddReviewAsync(rev);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Review added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Review not added",result);
    }

    public async Task<ApiResponse<bool>> ExistsAsync(int eventId,int attendeeId)
    {
        var result = await service.ExistsAsync(eventId, attendeeId);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Review exists",result)
        : new ApiResponse<bool>(HttpStatusCode.NotFound,"Review not found",result);
    }
}