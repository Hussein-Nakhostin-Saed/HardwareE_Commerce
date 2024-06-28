namespace HardwareE_commerce.Domain;

public record CategoryEditDto : EditDtoBase
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
