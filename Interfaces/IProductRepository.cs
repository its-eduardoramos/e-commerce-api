using api.Dtos;
using api.Models;

namespace api.Interfaces
{
  public interface IProductRepository
  {
    public Task<List<Product>> GetAllAsync();
    public Task<Product?> GetByIdAsync(int id);
    public Task<Product> CreateAsync(Product productModel);
    public Task<Product?> UpdateAsync(int id, UpdateProductRequest updateDto);
    public Task<Product?> DeleteAsync(int id);
  }
}