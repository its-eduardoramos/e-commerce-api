using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos
{
  public class UpdateCommentRequest
  {
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Content { get; set; } = string.Empty;
    [Required]
    public int Rating { get; set; }
  }
}