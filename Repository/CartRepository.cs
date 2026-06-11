using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class CartRepository : ICartRepository
  {
    private readonly ApplicationDbContext _context;
    public CartRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Cart?> GetAsync(string userId)
    {
      return await _context.Carts
        .Include(c => c.CartItems)
        .ThenInclude(ci => ci.Product)
        .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task<Cart> CreateAsync(Cart cart)
    {
      await _context.Carts.AddAsync(cart);
      await _context.SaveChangesAsync();
      return cart;
    }

    public async Task<Cart?> UpdateAsync(string userId, UpdateCartRequest updateDto)
    {
      var existingCart = await GetAsync(userId);
      if(existingCart is null) return null;

      existingCart.UpdatedAt = DateTime.UtcNow;

      foreach(var itemDto in updateDto.CartItems)
      {
        //If already existing in the cart
        var existingItem = existingCart.CartItems.FirstOrDefault(ci => ci.ProductId == itemDto.ProductId);

        if(existingItem is not null)
        {
          existingItem.Quantity = itemDto.Quantity;
        }
        else
        {
          existingCart.CartItems.Add(new CartItem
          {
            ProductId = itemDto.ProductId,
            Quantity = itemDto.Quantity
          });
        }
      }

      await _context.SaveChangesAsync();
      return existingCart;
    }

    public async Task<Cart?> DeleteCartItemAsync(string userId, int productId)
    {
      var existingCart = await GetAsync(userId);
      if(existingCart is null) return null;

      var cartItem = await _context.CartItems
          .FirstOrDefaultAsync(ci => ci.CartId == existingCart.Id && ci.ProductId == productId);
      if(cartItem is null) return null;

      _context.CartItems.Remove(cartItem);

      existingCart.UpdatedAt = DateTime.Now;
      await _context.SaveChangesAsync();
      return existingCart;
    }

    public async Task<Cart?> DeleteAsync(string userId)
    {
      var existingCart = await GetAsync(userId);
      if(existingCart is null) return null;
      
      _context.Carts.Remove(existingCart);
      await _context.SaveChangesAsync();
      return existingCart;
    }
  }
}