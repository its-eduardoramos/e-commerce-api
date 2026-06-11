namespace api.Models
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
  }
}