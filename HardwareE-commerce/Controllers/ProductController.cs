using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : BaseController<ProductAddDto, ProductEditDto, ProductDto, Product>
{
    public ProductController(ProductService service) : base(service)
    {
    }

    [Authorization(PermissionSignatures.CanEditProduct)]
    [Route("")]
    [HttpPost]
    public override Task InsertAsync(ProductAddDto dto) => base.InsertAsync(dto);

    [Authorization(PermissionSignatures.CanEditProduct)]
    [Route("")]
    [HttpPut]
    public override Task UpdateAsync(ProductEditDto dto) => base.UpdateAsync(dto);

    [Authorization(PermissionSignatures.CanEditProduct)]
    [Route("")]
    [HttpDelete]
    public override Task DeleteAsync(int id) => base.DeleteAsync(id);

    [Authorization(PermissionSignatures.CanEditProduct)]
    [Route("delete/soft")]
    [HttpDelete]
    public override Task SoftDeleteAsync(int id) => base.SoftDeleteAsync(id);

    [Authorization(PermissionSignatures.ProductView)]
    [Route("")]
    [HttpGet]
    public override Task<IEnumerable<ProductDto>> GetAllAsync() => base.GetAllAsync();

    [Authorization(PermissionSignatures.ProductView)]
    [Route("all/pagination")]
    [HttpGet]
    public override Task<PagableListDtoBase<ProductDto>> GetAllPageable(PagableListDtoBase<ProductDto> dto) => base.GetAllPageable(dto);
}
