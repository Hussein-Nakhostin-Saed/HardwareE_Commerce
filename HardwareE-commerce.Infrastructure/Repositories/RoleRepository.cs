
namespace HardwareE_commerce.Infrastructure;

public class RoleRepository : SqlBaseRepository<Role>, IRoleRepository
{
    public RoleRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
