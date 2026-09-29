using Application.DTOs.Organizer;

namespace Application.Interfaces;

public interface IOrganizerService
{
    Task<ApiResponse<List<OrganizerDto>>> GetAllOrganizerAsync();
    Task<ApiResponse<OrganizerDto>> GetOrganizerByIdAsync(int id);
    Task<ApiResponse<bool>> AddOrganizerAsync(OrganizerCreateDto organizer);
    Task<ApiResponse<bool>> UpdateOrganizerAsync(int id,OrganizerUpdateDto organizer);
    Task<ApiResponse<bool>> DeleteOrganizerAsync(int id);
    Task<ApiResponse<bool>> ExistsAsync(int id);
}