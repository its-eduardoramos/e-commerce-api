namespace api.Models
{
  public class Brand
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null!;
    public List<Product> Products { get; set; } = new List<Product>();
  }
}