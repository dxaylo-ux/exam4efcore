using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Interface;

namespace Infrastructure.Repositories;

public class CategoryRepository(AppDbContext appDbContext) : ICategoryRepository
{
    private AppDbContext context = appDbContext;

    public async Task<List<Category>> GetAllCategoryAsync()
    {
        return await context.Categories
        .Include(x => x.Events)
        .ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await context.Categories
        .Include(x => x.Events)
        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> AddCategoryAsync(Category category)
    {
        context.Categories.Add(category);
        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        var cat = await context.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);

        if (cat != null)
        {
            cat.Name = category.Name;
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var cat = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        if (cat != null)
        {
            context.Categories.Remove(cat);
        }

        var result = await context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await context.Categories.AnyAsync(x => x.Id == id);
    }
}