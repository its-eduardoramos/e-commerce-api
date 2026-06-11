using api.Dtos;
using api.Models;

namespace api.Interfaces
{
  public interface IBrandRepository
  {
    public Task<List<Brand>> GetAllAsync();
    public Task<Brand?> GetByIdAsync(int id);
    public Task<Brand> CreateAsync(Brand brandModel);
    public Task<Brand?> UpdateAsync(int id, UpdateBrandRequest updateDto);
    public Task<Brand?> DeleteAsync(int id);
  }
}