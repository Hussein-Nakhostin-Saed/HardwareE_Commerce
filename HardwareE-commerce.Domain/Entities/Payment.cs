namespace HardwareE_commerce.Domain;

public class Payment : MutableEntity
{
    public decimal TotalAmount { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public List<PaymentItem> Items { get; set; }
    public Payment()
    {
        Items = new List<PaymentItem>();
    }

    public Payment(decimal totalAmount, int orderId) : this()
    {
        TotalAmount = totalAmount;
        OrderId = orderId;
    }
}
