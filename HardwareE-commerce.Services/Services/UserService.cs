namespace HardwareE_commerce.Services;

public class UserService : ServiceBase<UserAddDto, UserEditDto, UserDto, User>
{
    public UserService( IUserRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
