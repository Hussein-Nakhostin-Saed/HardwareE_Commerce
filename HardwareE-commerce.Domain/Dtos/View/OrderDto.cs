namespace HardwareE_commerce.Domain;

public record OrderDto : DtoBase
{
    public int TotalCount { get; set; }
    public decimal TotalAmount { get; set; }
    public int UserId { get; set; }
    public List<OrderItemDto> Items { get; set; }
    public OrderDto()
    {
        
    }
}
