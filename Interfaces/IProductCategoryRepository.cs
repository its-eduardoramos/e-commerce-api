namespace api.Models;

public interface IProductCategoryRepository
{
  public Task AddAsync(ProductCategory productCategory); 
  public Task SaveChangesAsync();
}