namespace HardwareE_commerce.Infrastructure;

public static class Extensions
{
    public static IQueryable<T> IncludeProperty<T>(this DbSet<T> dbset, params string[] properties) where T : Entity
    {
        var query = dbset.AsQueryable();

        foreach (var property in properties)
        {
            if (string.IsNullOrEmpty(property))
                continue;

            query = query.Include(property);
        }

        return query;
    }
}
