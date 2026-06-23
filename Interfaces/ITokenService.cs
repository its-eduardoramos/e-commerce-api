using api.Models;

namespace api.Repository
{
  public interface ITokenService
  {
    public string CreateToken(AppUser user, string role);
  }
}