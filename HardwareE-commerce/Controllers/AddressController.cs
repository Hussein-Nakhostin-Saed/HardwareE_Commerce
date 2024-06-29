
using HardwareE_commerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/address")]
[ApiController]
public class AddressController : BaseController<AddressAddDto, AddressEditDto, AddressDto, Address>
{
    private readonly AddressService _service;
    public AddressController(AddressService service) : base(service)
    {
        _service = service;
    }

    [Authorization(PermissionSignatures.CanEditAddress)]
    [Route("")]
    [HttpPost]
    public override Task InsertAsync(AddressAddDto dto) => base.InsertAsync(dto);

    [Authorization(PermissionSignatures.CanEditAddress)]
    [Route("")]
    [HttpPut]
    public override Task UpdateAsync(AddressEditDto dto) => base.UpdateAsync(dto);

    [Authorization(PermissionSignatures.CanEditAddress)]
    [Route("")]
    [HttpDelete]
    public override Task DeleteAsync(int id) => base.DeleteAsync(id);

    [Authorization(PermissionSignatures.CanEditAddress)]
    [Route("delete/soft")]
    [HttpDelete]
    public override Task SoftDeleteAsync(int id) => base.SoftDeleteAsync(id);

    [Authorization(PermissionSignatures.AddressView)]
    [Route("")]
    [HttpGet]
    public override Task<IEnumerable<AddressDto>> GetAllAsync() => base.GetAllAsync();

    [Authorization(PermissionSignatures.AddressView)]
    [Route("user/all")]
    [HttpGet]
    public async Task<IEnumerable<AddressDto>> GetAllByUserAsync() => await _service.GetAllByUserAsync(UserContext.UserId);
}
