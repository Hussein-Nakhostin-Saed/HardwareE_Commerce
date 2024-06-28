namespace HardwareE_commerce.Domain;

[ObjectMapper]
public class GeneralMapper : Profile
{
    public GeneralMapper()
    {
        CreateMap<LogOnDto, User>()
            .ForMember(x => x.Password, opt => opt.MapFrom(c => (c.Password + "IranEnemiesWillDieSoon").Encrypt()));

        CreateMap<UserAddDto, User>()
            .ForMember(x => x.Password, opt => opt.MapFrom(c => (c.Password + "IranEnemiesWillDieSoon").Encrypt()));
        CreateMap<UserEditDto, User>();
        CreateMap<User, UserDto>();

        CreateMap<AddressAddDto, Address>();
        CreateMap<AddressEditDto, Address>();
        CreateMap<Address, AddressDto>();
    }
}

