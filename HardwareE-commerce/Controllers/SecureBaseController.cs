using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce;

public class SecureBaseController : ControllerBase
{
    UserContext _userContext;

    protected UserContext UserContext
    {
        get
        {
            if (_userContext is not null)
                return _userContext;

            var userId = User.Claims.Single(x => x.Type.Equals("UserId")).Value;
            var userName = User.Claims.Single(x => x.Type.Equals("UserName")).Value;

            var userContext = new UserContext(int.Parse(userId), userName);

            _userContext = userContext;

            return _userContext;
        }
    }
}
