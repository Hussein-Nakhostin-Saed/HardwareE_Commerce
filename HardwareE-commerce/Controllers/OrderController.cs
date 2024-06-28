using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController
{
    private readonly Orderserviec
    public OrderController()
    {
        
    }


    [Authorization(PermissionSignatures.CanEditCategory)]
    [Route("")]
    [HttpPost]
    public override Task InsertAsync(CategoryAddDto dto) => base.InsertAsync(dto);

    [Authorization(PermissionSignatures.CategoryView)]
    [Route("")]
    [HttpGet]
    public override Task<IEnumerable<CategoryDto>> GetAllAsync() => base.GetAllAsync();

    [Authorization(PermissionSignatures.CategoryView)]
    [Route("all/pagination")]
    [HttpGet]
    public override Task<PagableListDtoBase<CategoryDto>> GetAllPageable(PagableListDtoBase<CategoryDto> dto) => base.GetAllPageable(dto);

}
