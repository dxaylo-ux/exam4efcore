using Application.DTOs.Category;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<ApiResponse<List<CategoryDto>>> GetAllCategoryAsync();
    Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id);
    Task<ApiResponse<bool>> AddCategoryAsync(CategoryCreateDto category);
    Task<ApiResponse<bool>> UpdateCategoryAsync(int id,UpdateCategoryDto category);
    Task<ApiResponse<bool>> DeleteCategoryAsync(int id);
    Task<ApiResponse<bool>> ExistsAsync(int id);
}