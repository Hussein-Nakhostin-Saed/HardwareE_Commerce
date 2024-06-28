namespace HardwareE_commerce.Domain;

public class PagableListDtoBase<TDto> where TDto : DtoBase 
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public IEnumerable<TDto>? Entities { get; set; }
    private int _count;
    public int Count
    {
        get
        {
            return ((int)Math.Ceiling((double)(_count / Page)) + 1);
        }
    }

    public PagableListDtoBase()
    {

    }

    public PagableListDtoBase(int count, int pageSize, int pageIndex, IEnumerable<TDto> data)
    {
        PageSize = pageSize;
        Page = pageIndex;
        _count = count;
        Entities = data;
    }
}
