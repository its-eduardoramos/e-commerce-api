namespace api.Dtos
{
  public class ProductCategoryResponse
  {
    public int CategoryId { get; set; }
    public CategoryResponse Category { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  }
}