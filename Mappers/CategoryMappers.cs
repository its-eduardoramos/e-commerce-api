using api.Dtos;
using api.Models;

namespace api.Mappers
{
  public static class CategoryMappers
  {
    public static CategoryResponse ToResponse(this Category categoryModel)
    {
      return new CategoryResponse
      {
        Id = categoryModel.Id,
        Name = categoryModel.Name,
        CreatedAt = categoryModel.CreatedAt,
        UpdatedAt = categoryModel.UpdatedAt,

      };
    }

    public static Category ToEntity(this CreateCategoryRequest categoryDto)
    {
      return new Category
      {
        Name = categoryDto.Name,
      };
    }
  }
}