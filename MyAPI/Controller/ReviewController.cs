using Application.DTOs.Review;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class ReviewController(IReviewService reviewService) : ControllerBase
{
    private IReviewService service = reviewService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddReviewAsync(ReviewCreateDto review)
    {
        return await service.AddReviewAsync(review);
    }


    [HttpGet("event/{eventId:int}")]
    public async Task<ApiResponse<List<ReviewDto>>> GetReviewsByEventIdAsync(int eventId)
    {
        return await service.GetReviewsByEventIdAsync(eventId);
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<ReviewDto?>> GetReviewByIdAsync(int id)
    {
        return await service.GetReviewByIdAsync(id);
    }


    [HttpGet("exists")]
    public async Task<ApiResponse<bool>> ExistsAsync(int eventId,int attendeeId)
    {
        return await service.ExistsAsync(eventId, attendeeId);
    }
}