using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
  public class CartItem
  {
    public int CartId { get; set; }
    [ForeignKey("CartId")]
    public virtual Cart Cart { get; set; } = null!;
    public int ProductId { get; set; }
    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

  }
}