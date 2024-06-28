namespace HardwareE_commerce.Infrastructure;

public class UserRepository : SqlBaseRepository<User>, IUserRepository
{
    public UserRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
