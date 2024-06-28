namespace HardwareE_commerce.Domain;

public record PaymentDto : DtoBase
{
    public decimal TotalAmount { get; set; }
    /// <summary>
    /// پرداخت شده یا نه؟
    /// </summary>
    public bool Payed { get; set; }
    public int OrderId { get; set; }
}
