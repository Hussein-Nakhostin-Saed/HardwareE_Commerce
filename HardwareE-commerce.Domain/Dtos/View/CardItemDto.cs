namespace HardwareE_commerce.Domain;

public record CardItemDto : DtoBase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
