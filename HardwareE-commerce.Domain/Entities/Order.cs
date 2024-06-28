namespace HardwareE_commerce.Domain;

public class Order : MutableEntity
{
    public int TotalCount { get; set; }
    public decimal TotalAmount { get; set; }
    public int UserId { get; set; }
    public User user { get; set; }
    public ICollection<OrderItem> Items { get; set; }
    public Order()
    {
        
    }
}
