
using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/address")]
[ApiController]
public class AddressController : BaseController<AddressAddDto, AddressEditDto, AddressDto, Address>
{
    public AddressController(AddressService service) : base(service)
    {
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
    [Route("all/pagination")]
    [HttpGet]
    public override Task<PagableListDtoBase<AddressDto>> GetAllPageable(PagableListDtoBase<AddressDto> dto) => base.GetAllPageable(dto);
}
