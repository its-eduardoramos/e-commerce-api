namespace api.Dtos
{
  public class CartItemResponse
  {
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    //for the frontend
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }

  }
}