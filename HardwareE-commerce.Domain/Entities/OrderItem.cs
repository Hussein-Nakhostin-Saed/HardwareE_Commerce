namespace HardwareE_commerce.Domain;

public class OrderItem : MutableEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }

    public OrderItem()
    {
    }

    public OrderItem(int productId, int quantity, decimal totalAmount)
    {
        ProductId = productId;
        Quantity = quantity;
        TotalAmount = totalAmount;
    }
}
