using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
  public class UpdateCategoryRequest
  {
    [Required]
    public string Name { get; set; } = string.Empty;
  }
}