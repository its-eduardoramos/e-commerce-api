using api.Dtos;
using api.Models;

namespace api.Mappers
{
  public static class CartItemMappers
  {
    public static CartItemResponse ToResponse(this CartItem cartItem)
    {
      return new CartItemResponse
      {
        ProductId = cartItem.ProductId,
        Quantity = cartItem.Quantity,
        ProductName = cartItem.Product != null ? cartItem.Product.Name : string.Empty,
        Price = cartItem.Product != null ? cartItem.Product.Price : 0
      };
    }
  }
}