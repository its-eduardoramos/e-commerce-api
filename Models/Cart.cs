using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
  public class Cart
  {
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    [ForeignKey("UserId")]
    public virtual AppUser User { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
  }
}