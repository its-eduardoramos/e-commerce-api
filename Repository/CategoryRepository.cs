using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class CategoryRepository : ICategoryRepository
  {
    private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async  Task<List<Category>> GetAllAsync()
    {
      return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
      return await _context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category categoryModel)
    {
      await _context.Categories.AddAsync(categoryModel);
      await _context.SaveChangesAsync();
      return categoryModel;
    }

    public async Task<Category?> UpdateAsync(int id, UpdateCategoryRequest updateDto)
    {
      var existingCategory = await GetByIdAsync(id);
      if(existingCategory is null) return null;

      existingCategory.Name = updateDto.Name;
      existingCategory.UpdatedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync();
      return existingCategory;
    }

    public async Task<Category?> DeleteAsync(int id)
    {
      var deletedCategory = await GetByIdAsync(id);
      if (deletedCategory is null) return null;
      
      _context.Categories.Remove(deletedCategory);
      await _context.SaveChangesAsync();
      return deletedCategory;
    }
  }
}