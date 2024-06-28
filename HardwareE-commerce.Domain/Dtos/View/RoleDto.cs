namespace HardwareE_commerce.Domain;

public record RoleDto : DtoBase
{
    public string Name { get; set; }
    public IEnumerable<PermissionDto> Permissions { get; set; }
}
