using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
  public class UpdateCartRequest
  {
    [Required]
    public List<CreateCartItemRequest> CartItems { get; set; } = new List<CreateCartItemRequest>();

  }
}