using api.Dtos;
using api.Models;

namespace api.Interfaces
{
  public interface ICartRepository
  {
    public Task<Cart?> GetAsync(string userId);
    public Task<Cart> CreateAsync(Cart cart);
    public Task<Cart?> UpdateAsync(string userId, UpdateCartRequest updateDto);
    public Task<Cart?> DeleteCartItemAsync(string userId, int productId);
    public Task<Cart?> DeleteAsync(string userId);

  }
}