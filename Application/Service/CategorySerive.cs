using System.Net;
using Application.DTOs.Category;
using Domain.Interface;
using Domain.Models;
using Application.Interfaces;

namespace Application.Service;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
    private ICategoryRepository service = repository;

    public async Task<ApiResponse<List<CategoryDto>>> GetAllCategoryAsync()
    {
        var categories = await service.GetAllCategoryAsync();
        var result = categories.Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name

        }).ToList();

        return new ApiResponse<List<CategoryDto>>(HttpStatusCode.OK,"List of categories",result);
    }

    public async Task<ApiResponse<CategoryDto>> GetCategoryByIdAsync(int id)
    {
        var category = await service.GetCategoryByIdAsync(id);

        if (category == null)
        {
            return new ApiResponse<CategoryDto>(HttpStatusCode.NotFound,"Category not found",null!);
        }

        var result = new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };

        return new ApiResponse<CategoryDto>(HttpStatusCode.OK,"Category by id",result);
    }

    public async Task<ApiResponse<bool>> AddCategoryAsync(
        CategoryCreateDto category)
    {
        var cat = new Category
        {
            Name = category.Name
        };

        var result = await service.AddCategoryAsync(cat);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Category added",result)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError,"Category not added",result);
    }

    public async Task<ApiResponse<bool>> UpdateCategoryAsync(int id,UpdateCategoryDto category)
    {
        var cat = new Category
        {
            Id = id,
            Name = category.Name
        };

        var result = await service.UpdateCategoryAsync(cat);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Category updated",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Category cannot be updated",result);
    }

    public async Task<ApiResponse<bool>> DeleteCategoryAsync(int id)
    {
        var result = await service.DeleteCategoryAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Category deleted",result)
        : new ApiResponse<bool>(HttpStatusCode.BadRequest,"Category cannot be deleted",result);
    }

    public async Task<ApiResponse<bool>> ExistsAsync(int id)
    {
        var result = await service.ExistsAsync(id);
        return result

        ? new ApiResponse<bool>(HttpStatusCode.OK,"Category exists",result)
        : new ApiResponse<bool>(HttpStatusCode.NotFound,"Category not found",result);
    }
}