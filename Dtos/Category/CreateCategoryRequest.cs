using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
  public class CreateCategoryRequest
  {
    [Required]
    public string Name { get; set; } = string.Empty;
  }
}