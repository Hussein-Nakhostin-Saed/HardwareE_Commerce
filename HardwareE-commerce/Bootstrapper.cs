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
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<ICardRepository, CardRepository>();
        //Services
        services.AddScoped<UserService>();
        services.AddScoped<AddressService>();
        services.AddScoped<RoleService>();
        services.AddScoped<SecurityService>();
        services.AddScoped<CategoryService>();
        services.AddScoped<CardService>();
        services.AddScoped<ProductService>();
        //Validations
        services.AddScoped<UserSpecification>();
        services.AddScoped<ProductSpecification>();
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ObjectMappingProfile));
    }
}
