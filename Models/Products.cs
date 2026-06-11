using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]//Para asegurarse que el cmapo es unicamente de monto
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
    public int BrandId { get; set; }
    [ForeignKey("BrandId")]
    public virtual Brand Brand { get; set; } = null!;
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
  }
}