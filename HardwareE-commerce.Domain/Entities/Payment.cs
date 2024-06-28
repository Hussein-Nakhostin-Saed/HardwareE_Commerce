namespace HardwareE_commerce.Domain;

public class Payment : MutableEntity
{
    public decimal TotalAmount { get; set; }
    /// <summary>
    /// پرداخت شده یا نه؟
    /// </summary>
    public bool Payed { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public Payment()
    {
        
    }
}
