namespace HardwareE_commerce.Services;

public class RoleService : ServiceBase<RoleAddDto, RoleEditDto, RoleDto, Role>
{
    public RoleService(IRoleRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
