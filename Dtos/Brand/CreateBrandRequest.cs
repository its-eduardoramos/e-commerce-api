using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
  public class CreateBrandRequest
  {
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Logo { get; set; } = string.Empty;
  }
}