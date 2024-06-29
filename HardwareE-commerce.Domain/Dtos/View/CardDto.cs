namespace HardwareE_commerce.Domain;

public record CardDto : DtoBase
{
    public int TotalCount { get; set; }
    public IEnumerable<CardItemDto> CardItems { get; set; }
}
