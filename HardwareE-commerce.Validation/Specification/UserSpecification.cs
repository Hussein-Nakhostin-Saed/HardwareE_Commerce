namespace HardwareE_commerce.Validation;

public class UserSpecification : SpecificationBase<User>
{
    private readonly IUserRepository _userRepository;
    public UserSpecification(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override Expression<Func<User, bool>> SpecificationExpression
    {
        get
        {
            Expression<Func<User, bool>> spec = c => !c.Equals(_userRepository.GetOrDefualt(x => x.NationalNo.Equals(c.NationalNo)).Result);
            return spec;
        }
    }
}
