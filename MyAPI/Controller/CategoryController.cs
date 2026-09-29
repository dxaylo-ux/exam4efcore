using Application.DTOs.Category;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class CategoryController(ICategoryService categoryService) : ControllerBase
{
    private ICategoryService service = categoryService;


    [HttpPost]
    public async Task<ApiResponse<bool>> AddCategoryAsync(
        CategoryCreateDto category)
    {
        return await service.AddCategoryAsync(category);
    }


    [HttpGet]
    public async Task<ApiResponse<List<CategoryDto>>> GetCategoriesAsync()
    {
        return await service.GetAllCategoryAsync();
    }


    [HttpGet("{id:int}")]
    public async Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id)
    {
        return await service.GetCategoryByIdAsync(id);
    }


    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateCategoryAsync(
        int id,
        UpdateCategoryDto category)
    {
        return await service.UpdateCategoryAsync(id, category);
    }


    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
    {
        return await service.DeleteCategoryAsync(id);
    }


    [HttpGet("{id:int}/exists")]
    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        return await service.ExistsAsync(id);
    }
}