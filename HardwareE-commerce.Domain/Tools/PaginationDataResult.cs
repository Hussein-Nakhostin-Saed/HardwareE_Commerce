namespace HardwareE_commerce.Domain;

public class PaginationDataResult<TEntity> where TEntity : Entity
{
    public int Count { get; set; }

    public int PageSize { get; set; }

    public int Page { get; set; }

    public IEnumerable<TEntity>? Entities { get; set; }

    public PaginationDataResult(int count, int pageSize, int page, IEnumerable<TEntity>? entities)
    {
        Count = count;
        PageSize = pageSize;
        Page = page;
        Entities = entities;
    }
}
