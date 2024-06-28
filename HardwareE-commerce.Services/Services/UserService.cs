using HardwareE_commerce.Validation;

namespace HardwareE_commerce.Services;

public class UserService : ServiceBase<UserAddDto, UserEditDto, UserDto, User>
{
    private readonly UserSpecification _userSpecification;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository repository, IMapper mapper, UserSpecification specification) : base(repository, mapper)
    {
        _userSpecification = specification;
        _mapper = mapper;
        _userRepository = repository;
    }

    public override async Task InsertAsync(UserAddDto dto)
    {
        var entity = _mapper.Map<User>(dto);

        if (_userSpecification.IsSatisfied(entity))
            throw new Exception("Invalid User");

        entity.CreateAt = DateTime.Now;
        entity.DocumentState = DocumentState.Registered;

        await _userRepository.Insert(entity);
        await _userRepository.SaveChanges();
    }
}
