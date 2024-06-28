namespace HardwareE_commerce.Services;

public class ServiceBase<TAddDto, TEditDto, TDto, TEntity> where TAddDto : AddDtoBase
                                                           where TEditDto : EditDtoBase
                                                           where TDto : DtoBase
                                                           where TEntity : MutableEntity
{
    private readonly ISqlBaseRepository<TEntity> _repository;
    private readonly IMapper _mapper;
    public ServiceBase(ISqlBaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task InsertAsync(TAddDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.CreateAt = DateTime.Now;
        entity.DocumentState = DocumentState.Registered;

        await _repository.Insert(entity);
        await _repository.SaveChanges();
    }

    public async Task UpdateAsync(TEditDto dto)
    {
        var entity = await _repository.GetById(dto.Id);
        _mapper.Map(entity, dto);
        entity.ModifiedAt = DateTime.Now;
        entity.DocumentState = DocumentState.Modified;

        await _repository.SaveChanges();
    }

    public async Task SoftDeleteAsync(int id)
    {
        var entity = await _repository.GetById(id);
        entity.DeletedAt = DateTime.Now;
        entity.DocumentState = DocumentState.Deleted;

        await _repository.SaveChanges();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.Delete(id);
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAll(x => x.DocumentState != DocumentState.Deleted);
        var dtos = _mapper.MapCollection<TEntity, TDto>(entities);

        return dtos;
    }

    public async Task<PagableListDtoBase<TDto>> GetAllPageable(PagableListDtoBase<TDto> dto)
    {
        var entities = await _repository.GetAll(x => x.DocumentState != DocumentState.Deleted, dto.Page, dto.PageSize);
        var dtos = _mapper.MapPaginationResult<TEntity, TDto>(entities);

        return dtos;
    }
}
