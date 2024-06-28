using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/security")]
[ApiController]
public class SecurityController : SecureBaseController
{
    private readonly SecurityService _securityService;
    public SecurityController(SecurityService securityService)
    {
        _securityService = securityService;
    }

    [HttpPost]
    [Route("login")]
    public async Task LogIn(LoginDto dto)
    {
        var identity = await _securityService.Login(dto);
        await HttpContext.SetAuthenticationTokenAsync(identity.UserId, identity.Username, identity.permissions);
    }

    [HttpPost]
    [Route("logon")]
    public async Task LogOn(LogOnDto dto)
    {
        await _securityService.LogOn(dto);
    }

    [Authorization]
    [HttpPost]
    [Route("logout")]
    public async Task LogOut()
    {
        await HttpContext.SignOutAsync();
    }

    [Authorization]
    [HttpPost]
    [Route("changepassword")]
    public async Task ChangePassword(ChangePasswordDto dto)
    {
        await _securityService.ChangePassword(dto);
    }
}
