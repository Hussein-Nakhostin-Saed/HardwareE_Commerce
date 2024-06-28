namespace HardwareE_commerce.Domain;

public record ProductAddDto : AddDtoBase
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
}
