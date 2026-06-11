using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<List<Product>> GetAllAsync()
    {
      return await _context.Products.Include(p => p.Brand).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
      return await _context.Products
        .Include(p => p.Brand)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> CreateAsync(Product productModel)
    {
      await _context.Products.AddAsync(productModel);
      await _context.SaveChangesAsync();
      return productModel;
    }

    public async Task<Product?> UpdateAsync(int id, UpdateProductRequest updateDto)
    {
      var existingProduct = await GetByIdAsync(id);
      if (existingProduct is null) return null;

      existingProduct.Name = updateDto.Name;
      existingProduct.Description = updateDto.Description;
      existingProduct.Price = updateDto.Price;
      existingProduct.Stock = updateDto.Stock;
      existingProduct.ImageUrl = updateDto.ImageUrl;
      existingProduct.BrandId = updateDto.BrandId;
      existingProduct.UpdatedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync();
      return existingProduct;
    }

    public async Task<Product?> DeleteAsync(int id)
    {
      var existingProduct = await _context.Products.FindAsync(id);
      if (existingProduct is null) return null;

      _context.Remove(existingProduct);
      await _context.SaveChangesAsync();
      return existingProduct;
    }
  }
}