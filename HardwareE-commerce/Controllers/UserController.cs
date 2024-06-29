using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/user")]
[ApiController]
public class UserController : BaseController<UserAddDto, UserEditDto, UserDto, User>
{
    public UserController(UserService service) : base(service)
    {
    }

    [Authorization(PermissionSignatures.CanEditUser)]
    [Route("")]
    [HttpPost]
    public override Task InsertAsync(UserAddDto dto) => base.InsertAsync(dto);

    [Authorization(PermissionSignatures.CanEditUser)]
    [Route("")]
    [HttpPut]
    public override Task UpdateAsync(UserEditDto dto) => base.UpdateAsync(dto);

    [Authorization(PermissionSignatures.CanEditUser)]
    [Route("")]
    [HttpDelete]
    public override Task DeleteAsync(int id) => base.DeleteAsync(id);

    [Authorization(PermissionSignatures.CanEditUser)]
    [Route("delete/soft")]
    [HttpDelete]
    public override Task SoftDeleteAsync(int id) => base.SoftDeleteAsync(id);

    [Authorization(PermissionSignatures.UserView)]
    [Route("")]
    [HttpGet]
    public override Task<IEnumerable<UserDto>> GetAllAsync() => base.GetAllAsync();
}
