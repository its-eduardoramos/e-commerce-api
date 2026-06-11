using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
  public class CreateCartRequest
  {
    [Required]
    public List<CreateCartItemRequest> CartItems { get; set; } = new List<CreateCartItemRequest>();

  }
}