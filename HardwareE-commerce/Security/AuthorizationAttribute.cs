using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HardwareE_commerce;

public class AuthorizationAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _permission;
    public AuthorizationAttribute() : base()
    {
    }

    public AuthorizationAttribute(string pemission) : base()
    {
        _permission = pemission;
    }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context != null)
        {
            var user = context.HttpContext.User;

            if (!string.IsNullOrEmpty(_permission))
            {
                var userPermissions = user.Claims.Single(x => x.Type == "Permissions").Value.Split(',');

                var isValidUser = userPermissions.Any(x => x.Equals(_permission));

                if (!isValidUser)
                    throw new UnauthorizedAccessException();
            }
        }
    }
}
