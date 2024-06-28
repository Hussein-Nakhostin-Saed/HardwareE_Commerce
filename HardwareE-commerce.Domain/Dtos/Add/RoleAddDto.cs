namespace HardwareE_commerce.Domain;

public record RoleAddDto : AddDtoBase
{
    public string Name { get; set; }
    public ICollection<PermissionDto> Permissions { get; set; }
}
