namespace HardwareE_commerce.Domain;

public record CategoryAddDto : AddDtoBase
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
}
