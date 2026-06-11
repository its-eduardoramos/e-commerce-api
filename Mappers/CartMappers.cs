using api.Dtos;
using api.Models;

namespace api.Mappers
{
  public static class CartMappers
  {
    public static CartResponse ToResponse(this Cart cartModel)
    {
      return new CartResponse
      {
        Id = cartModel.Id,
        UserId = cartModel.UserId,
        CartItems = cartModel.CartItems.Select(ci => ci.ToResponse()).ToList()
      };
    }

    public static Cart ToEntity(this CreateCartRequest cartDto, string userId)
    {
      return new Cart
      {
        UserId = userId,
        CartItems = cartDto.CartItems.Select(c => new CartItem
        {
          ProductId = c.ProductId,
          Quantity = c.Quantity
        }).ToList()
      };
    }
  }
}