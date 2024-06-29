using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/category")]
[ApiController]
public class CategoryController : BaseController<CategoryAddDto, CategoryEditDto, CategoryDto, Category>
{
    public CategoryController(CategoryService service) : base(service)
    {
    }


    [Authorization(PermissionSignatures.CanEditCategory)]
    [Route("")]
    [HttpPost]
    public override Task InsertAsync([FromBody] CategoryAddDto dto) => base.InsertAsync(dto);

    [Authorization(PermissionSignatures.CanEditCategory)]
    [Route("")]
    [HttpPut]
    public override Task UpdateAsync(CategoryEditDto dto) => base.UpdateAsync(dto);

    [Authorization(PermissionSignatures.CanEditCategory)]
    [Route("")]
    [HttpDelete]
    public override Task DeleteAsync(int id) => base.DeleteAsync(id);

    [Authorization(PermissionSignatures.CanEditCategory)]
    [Route("delete/soft")]
    [HttpDelete]
    public override Task SoftDeleteAsync(int id) => base.SoftDeleteAsync(id);

    [Authorization(PermissionSignatures.CategoryView)]
    [Route("")]
    [HttpGet]
    public override Task<IEnumerable<CategoryDto>> GetAllAsync() => base.GetAllAsync();
}
