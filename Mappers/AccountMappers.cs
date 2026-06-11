using api.Dtos;
using api.Models;

namespace api.Mappers
{
  public static class AccountMappers
  {
    public static AccountResponse ToResponse(this AppUser accountDto, string token)
    {
      return new AccountResponse
      {
        UserName = accountDto.UserName,
        Email = accountDto.Email,
        Token = token
      };
    }

    public static AppUser ToEntity(this CreateAccountRequest accountDto)
    {
      return new AppUser
      {
        UserName = accountDto.UserName,
        Email = accountDto.Email
      };
    }
  }
}