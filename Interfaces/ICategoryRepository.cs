using api.Dtos;
using api.Models;

namespace api.Interfaces
{
  public interface ICategoryRepository
  {
    public Task<List<Category>> GetAllAsync();
    public Task<Category?> GetByIdAsync(int id);
    public Task<Category> CreateAsync(Category categoryModel);
    public Task<Category?> UpdateAsync(int id, UpdateCategoryRequest updateDto);
    public Task<Category?> DeleteAsync(int id);
  }
}