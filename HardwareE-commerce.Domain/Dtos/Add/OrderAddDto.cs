namespace HardwareE_commerce.Domain;

public record OrderAddDto : AddDtoBase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
}
