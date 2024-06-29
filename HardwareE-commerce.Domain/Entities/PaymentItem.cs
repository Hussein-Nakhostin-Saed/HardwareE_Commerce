namespace HardwareE_commerce.Domain;

public class PaymentItem : Entity
{
    public DateTime CreateAt { get; set; }
    public OrderItem OrderItem { get; set; }
    public int OrderItemId { get; set; }
    public decimal TotalAmount { get; set; }

    public PaymentItem()
    {
    }

    public PaymentItem(decimal totalAmount, int orderItemId)
    {
        CreateAt = DateTime.Now;
        TotalAmount = totalAmount;
        OrderItemId = orderItemId;
    }
}
