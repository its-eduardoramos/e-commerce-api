using api.Dtos;
using api.Mappers;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/account")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] CreateLoginRequest loginDto)
    {
      var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName.Contains(loginDto.UserName.ToLower()));
      if(existingUser is null) return Unauthorized("User/password invalid");

      var passwordExists = await _signInManager.CheckPasswordSignInAsync(existingUser, loginDto.Password, false);
      if(!passwordExists.Succeeded) return Unauthorized("User/password invalid");
      
      var token = _tokenService.CreateToken(existingUser);
      return Ok(existingUser.ToResponse(token));
    }

    [Authorize]
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateAccountRequest accountDto)
    {
      try
      {
        var appUser = accountDto.ToEntity();
        var createdUser = await _userManager.CreateAsync(appUser, accountDto.Password);

        if (createdUser.Succeeded)
        {
          var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
          
          if(roleResult.Succeeded)
          {
            var token = _tokenService.CreateToken(appUser);
            return Ok(appUser.ToResponse(token));
          }
          else
          {
            return StatusCode(500, roleResult.Errors);
          }
        }
        else
        {
          return StatusCode(500, createdUser.Errors);
        }
      }
      catch (Exception e)
      {
        return StatusCode(500, e);
      }
    }
  }
}