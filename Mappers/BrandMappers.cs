using api.Dtos;
using api.Models;

namespace api.Mappers
{
  public static class BrandMappers
  {
    public static BrandResponse ToResponse(this Brand brandModel)
    {
      return new BrandResponse
      {
        Id = brandModel.Id,
        Name = brandModel.Name,
        Logo = brandModel.Logo,
        CreatedAt = brandModel.CreatedAt,
        UpdatedAt = brandModel.UpdatedAt,

      };
    }

    public static Brand ToEntity(this CreateBrandRequest brandDto)
    {
      return new Brand
      {
        Name = brandDto.Name,
        Logo = brandDto.Logo,
      };
    }
  }
}