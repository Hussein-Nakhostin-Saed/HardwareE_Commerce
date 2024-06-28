namespace HardwareE_commerce.Domain;

public record CategoryDto : DtoBase
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
