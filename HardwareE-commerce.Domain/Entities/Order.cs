using System.Collections.ObjectModel;

namespace HardwareE_commerce.Domain;

public class Order : MutableEntity
{
    public int TotalCount { get; set; }
    public decimal TotalAmount { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<OrderItem> Items { get; set; }
    public Payment? Payment { get; set; }
    public int? PaymentId { get; set; }
    public Order()
    {
        Items = new List<OrderItem>();
    }
    public Order(int totalCount, decimal totalAmount, int userId)
    {
        Items = new List<OrderItem>();
        TotalCount = totalCount;
        TotalAmount = totalAmount;
        UserId = userId;
    }
}
