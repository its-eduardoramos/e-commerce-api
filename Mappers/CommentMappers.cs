using api.Dtos;
using api.Models;

namespace api.Mappers
{
  public static class CommentMappers
  {
    public static CommentResponse ToResponse(this Comment commentModel)
    {
      return new CommentResponse
      {
        Id = commentModel.Id,
        Title = commentModel.Title,
        Content = commentModel.Content,
        Rating = commentModel.Rating,
        ProductId = commentModel.ProductId,
        UserId = commentModel.UserId,
        CreatedAt = commentModel.CreatedAt,
        UpdatedAt = commentModel.UpdatedAt,

      };
    }

    public static Comment ToEntity(this CreateCommentRequest commentDto)
    {
      return new Comment
      {
        Title = commentDto.Title,
        Content = commentDto.Content,
        Rating = commentDto.Rating,
        ProductId = commentDto.ProductId,
        UserId = commentDto.UserId
      };
    }
  }
}