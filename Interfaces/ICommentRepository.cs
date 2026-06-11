using api.Dtos;
using api.Models;

namespace api.Interfaces
{
  public interface ICommentRepository
  {
    public Task<Comment?> GetByIdAsync(int id);
    public Task<Comment> CreateAsync(Comment commentModel);
    public Task<Comment?> UpdateAsync(int id, UpdateCommentRequest updateDto);
    public Task<Comment?> DeleteAsync(int id);
  }
}