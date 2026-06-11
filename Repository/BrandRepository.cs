using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class BrandRepository : IBrandRepository
  {
    private readonly ApplicationDbContext _context;
    public BrandRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
      return await _context.Brands.ToListAsync();
    }

    public async Task<Brand?> GetByIdAsync(int id)
    {
      return await _context.Brands.FindAsync(id);
    }

    public async Task<Brand> CreateAsync(Brand brandModel)
    {
      await _context.AddAsync(brandModel);
      await _context.SaveChangesAsync();
      return brandModel;
    }

    public async Task<Brand?> UpdateAsync(int id, UpdateBrandRequest updateDto)
    {
      var existingBrand = await GetByIdAsync(id);
      if(existingBrand is null) return null;

      existingBrand.Name = updateDto.Name;
      existingBrand.Logo = updateDto.Logo;
      existingBrand.UpdatedAt = DateTime.UtcNow;

      await _context.SaveChangesAsync();
      return existingBrand;
    }

    public async Task<Brand?> DeleteAsync(int id)
    {
      var existingBrand = await GetByIdAsync(id);
      if(existingBrand is null) return null;

      _context.Remove(existingBrand);
      await _context.SaveChangesAsync();
      return existingBrand;
    }
  }
}