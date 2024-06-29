using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce;

[Authorize]
[ApiController]
public class BaseController<TAddDto, TEditDto, TDto, TEntity>  : SecureBaseController 
                                                                 where TAddDto : AddDtoBase
                                                                 where TEditDto : EditDtoBase
                                                                 where TDto : DtoBase
                                                                 where TEntity : MutableEntity
{
    private readonly ServiceBase<TAddDto, TEditDto, TDto, TEntity> _service;
    public BaseController(ServiceBase<TAddDto, TEditDto, TDto, TEntity> service)
    {
        _service = service;
    }

    [HttpPost]
    public virtual async Task InsertAsync(TAddDto dto) => await _service.InsertAsync(dto);

    [HttpPut]
    public virtual async Task UpdateAsync(TEditDto dto) => await _service.UpdateAsync(dto);

    [HttpDelete]
    public virtual async Task DeleteAsync(int id) => await _service.DeleteAsync(id);

    [HttpDelete]
    public virtual async Task SoftDeleteAsync(int id) => await _service.SoftDeleteAsync(id);

    [HttpGet]
    public virtual async Task<IEnumerable<TDto>> GetAllAsync() => await _service.GetAllAsync();
}
