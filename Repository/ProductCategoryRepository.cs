using api.Data;
using api.Models;

namespace api.Repository
{
  public class ProductCategoryRepository : IProductCategoryRepository
  {
    private readonly ApplicationDbContext _context;
    public ProductCategoryRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task AddAsync(ProductCategory productCategory)
    {
      await _context.ProductCategories.AddAsync(productCategory);
    }

    public async Task SaveChangesAsync()
    {
      await _context.SaveChangesAsync();
    }
  }
}