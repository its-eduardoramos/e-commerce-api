using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
  public class CreateCartItemRequest
  {
    [Required]
    public int ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "The quantity must be at least 1.")]
    public int Quantity { get; set; }
  }
}