namespace HardwareE_commerce;

public static class CookieConfiguration
{
    public static void ConfigCookie(this IServiceCollection services)
    {
        services.AddAuthentication("auth").AddCookie("auth", config =>
        {
            config.Cookie.Name = "tk";
            config.LoginPath = "/login";
        });
    }
}
