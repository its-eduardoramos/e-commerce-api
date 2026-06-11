using System.ComponentModel.DataAnnotations.Schema;
using api.Models;

namespace api.Dtos
{
  public class CartResponse
  {
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public List<CartItemResponse> CartItems { get; set; } = new List<CartItemResponse>();
  }
}