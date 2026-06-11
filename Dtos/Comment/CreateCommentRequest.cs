using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos
{
  public class CreateCommentRequest
  {
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Content { get; set; } = string.Empty;
    [Required]
    public int Rating { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public string UserId { get; set; } = string.Empty;
  }
}