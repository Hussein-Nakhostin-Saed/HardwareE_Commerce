namespace HardwareE_commerce.Domain;

public record PaymentDto : DtoBase
{
    public decimal TotalAmount { get; set; }
    public int OrderId { get; set; }
    public DateTime CreateAt { get; set; }
    public IEnumerable<PaymentItemDto> Items { get; set; }
}
