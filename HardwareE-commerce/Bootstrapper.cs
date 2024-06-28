using HardwareE_commerce.Infrastructure;
using HardwareE_commerce.Validation;

namespace HardwareE_commerce;

public static class Bootstrapper
{
    public static void RegisterServices(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        //Services
        services.AddScoped<UserService>();
        services.AddScoped<AddressService>();
        services.AddScoped<RoleService>();
        services.AddScoped<SecurityService>();
        //Validations
        services.AddScoped<UserSpecification>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ObjectMappingProfile));
    }
}
