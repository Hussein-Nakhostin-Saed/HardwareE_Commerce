namespace HardwareE_commerce.Domain;

public record CardAddDto : AddDtoBase
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
