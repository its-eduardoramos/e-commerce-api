using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
  public class CreateProductRequest
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    public string ImageUrl { get; set; } = string.Empty;
    [Required]
    public int BrandId { get; set; }
  }
}