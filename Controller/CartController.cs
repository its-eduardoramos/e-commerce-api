using System.Security.Claims;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [Route("api/cart")]
  [ApiController]
  [Authorize]
  public class CartController : ControllerBase
  {
    private readonly ICartRepository _cartRepository;
    public CartController(ICartRepository cartRepository)
    {
      _cartRepository = cartRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetById()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if(userId is null) return Unauthorized();

      var cart = await _cartRepository.GetAsync(userId);
      if(cart is null) return NotFound();

      return Ok(cart.ToResponse());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCartRequest cartDto)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if(userId is null) return Unauthorized();

      var cartModel = cartDto.ToEntity(userId);
      var createdCart = await _cartRepository.CreateAsync(cartModel);

      return CreatedAtAction(
        nameof(GetById),
        new { },
        createdCart.ToResponse()
      );
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartRequest updateDto)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null) return Unauthorized();
      var updatedCart = await _cartRepository.UpdateAsync(userId, updateDto);

      if(updatedCart is null) return NotFound();

      return Ok(updatedCart.ToResponse());
    }

    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeleteCartItem([FromRoute] int productId)
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if(userId is null) return Unauthorized();

      var deletedCartItem = await _cartRepository.DeleteCartItemAsync(userId, productId);
      if(deletedCartItem is null) return NotFound();

      return Ok(deletedCartItem.ToResponse());
    }


    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      if (userId is null) return Unauthorized();

      var deletedCart = await _cartRepository.DeleteAsync(userId);
      if (deletedCart == null) return NotFound();

      return NoContent();
    }
  }
}