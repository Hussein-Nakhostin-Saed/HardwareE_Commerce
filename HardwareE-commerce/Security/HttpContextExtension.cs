using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace HardwareE_commerce;

public static class HttpContextExtension
{
    public static async Task SetAuthenticationTokenAsync(this HttpContext httpContext, int userId, string username, IEnumerable<string> permissions)
    {
        var cliams = new List<Claim>()
        {
            new Claim(ClaimTypes.UserData, userId.ToString()),
            new Claim(ClaimTypes.Name, username),
            new Claim("Permissions", string.Join(",", permissions)),
        };

        var claimIdentity = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme);
        var claimPrincipale = new ClaimsPrincipal(claimIdentity);
        var authenticationProperty = new AuthenticationProperties
        {
            AllowRefresh = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
            IsPersistent = true,
            IssuedUtc = DateTime.UtcNow,
            RedirectUri = "login"
        };

        await httpContext.SignInAsync(null,
                                      claimPrincipale,
                                      authenticationProperty);
    }
}
