using api.Models;

namespace api.Dtos
{
  public class CommentResponse
  {
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
    public string UserId { get; set; } = string.Empty;
    public virtual AppUser User { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = null;
  }
}