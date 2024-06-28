using HardwareE_commerce.Validation;

namespace HardwareE_commerce.Services;

public class SecurityService
{
    private readonly IUserRepository _userRepository;
    private readonly UserSpecification _userSpecification;
    private readonly IMapper _mapper;
    public SecurityService(IUserRepository userRepository, UserSpecification userSpecification, IMapper mapper)
    {
        _userRepository = userRepository;
        _userSpecification = userSpecification;
        _mapper = mapper;
    }

    public async Task<UserIdentityDto> Login(LoginDto dto)
    {
        var user = await _userRepository.GetOrDefualt(x => x.NationalNo == dto.NationalNo, "Role.Permissions");
        if (user is not null)
        {
            if (user.Password.Decrypt().Equals(dto.Password + "IranEnemiesWillDieSoon"))
            {
                user.LastEntryDateTime = DateTime.Now;
                await _userRepository.SaveChanges();
                var permissions = user.Role is not null ? user.Role.Permissions.Select(c => c.Code) : null;
                return new UserIdentityDto(user.Id, dto.NationalNo, permissions!);
            }
        }
        return null!;
    }

    public async Task LogOn(LogOnDto dto)
    {
        var user = _mapper.Map<LogOnDto, User>(dto);

        if (_userSpecification.IsSatisfied(user))
            throw new Exception("Invalid User");

        await _userRepository.Insert(user);

        await _userRepository.SaveChanges();
    }

    public async Task ChangePassword(ChangePasswordDto dto)
    {
        var user = await _userRepository.GetById(dto.UserId);
        if (user is not null && user.Password.Decrypt().Equals(dto.Password + "IranEnemiesWillDieSoon"))
        {
            if (dto.newPassword == dto.ConfirmNewPassword)
            {
                user.Password = (dto.newPassword + "IranEnemiesWillDieSoon").Encrypt();
            }
        }
    }

    public async Task SetRole(SetRoleDto dto)
    {
        var user = await _userRepository.GetById(dto.UserId);
        user.RoleId = dto.RoleId;

        await _userRepository.SaveChanges();
    }
}
