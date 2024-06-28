namespace HardwareE_commerce.Domain;

public record RoleEditDto : EditDtoBase
{
    public string Name { get; set; }
    public IEnumerable<PermissionDto> Permissions { get; set; }
}
