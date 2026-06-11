using api.Dtos;
using api.Models;

namespace api.Mappers
{
  public static class ProductMappers
  {
    public static ProductResponse ToResponse(this Product productModel)
    {
      return new ProductResponse
      {
        Id = productModel.Id,
        Name = productModel.Name,
        Description = productModel.Description,
        Price = productModel.Price,
        Stock = productModel.Stock,
        ImageUrl = productModel.ImageUrl,
        CreatedAt = productModel.CreatedAt,
        UpdatedAt = productModel.UpdatedAt,
        BrandId = productModel.BrandId,
        BrandName = productModel.Brand != null ? productModel.Brand.Name : string.Empty
      };
    }

    public static Product ToEntity(this CreateProductRequest productDto)
    {
      return new Product
      {
        Name = productDto.Name,
        Description = productDto.Description,
        Price = productDto.Price,
        Stock = productDto.Stock,
        ImageUrl = productDto.ImageUrl,
        BrandId = productDto.BrandId
      };
    }
  }
}