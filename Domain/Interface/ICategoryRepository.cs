using Domain.Models;

namespace Domain.Interface;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllCategoryAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<bool> AddCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
    Task<bool> ExistsAsync(int id);
}