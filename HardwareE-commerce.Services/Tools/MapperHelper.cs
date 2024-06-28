using System.Collections.ObjectModel;

namespace HardwareE_commerce.Services;

public static class MapperHelper
{
    public static ICollection<TDestination> MapCollection<TSource, TDestination>(this IMapper mapper, IEnumerable<TSource> sources)
    {
        var collection = new Collection<TDestination>();
        foreach (TSource source in sources)
            collection.Add(mapper.Map<TDestination>(source));

        return collection;
    }

    public static PagableListDtoBase<TDestination> MapPaginationResult<TSource, TDestination>(this IMapper mapper, PaginationDataResult<TSource> sources) where TSource : Entity where TDestination : DtoBase
    {
        var list = new PagableListDtoBase<TDestination>(sources.Count, sources.PageSize, sources.Page, null!);
        list.Entities = mapper.MapCollection<TSource, TDestination>(sources.Entities ?? Enumerable.Empty<TSource>());

        return list;
    }
}
