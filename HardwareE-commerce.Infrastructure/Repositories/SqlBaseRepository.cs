using System.Linq.Expressions;

namespace HardwareE_commerce.Infrastructure;

public class SqlBaseRepository<TEntity> : ISqlBaseRepository<TEntity> where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet;
    private readonly E_CommerceContext _dbContext;
    public SqlBaseRepository(E_CommerceContext dbContext)
    {
        _dbSet = dbContext.Set<TEntity>();
        _dbContext = dbContext;
    }

    public async Task Insert(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task InsertMany(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task Delete(int id)
    {
        var entity = await _dbSet.SingleAsync(x => x.Id == id);
        _dbSet.Remove(entity);
    }

    public async Task Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task DeleteMany(IEnumerable<int> ids)
    {
        var entities = await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        _dbSet.RemoveRange(entities);
    }

    public async Task DeleteMany(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task DeleteMany(Expression<Func<TEntity, bool>> expression)
    {
        var entities = await _dbSet.Where(expression).ToListAsync();
        _dbSet.RemoveRange(entities);
    }

    public async Task<IEnumerable<TEntity>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll(params string[] includableProperties)
    {
        return await _dbSet.IncludeProperty(includableProperties).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, params string[] includableProperties)
    {
        return await _dbSet.IncludeProperty(includableProperties)
                           .Where(expression)
                           .ToListAsync();
    }

    public async Task<PaginationDataResult<TEntity>> GetAll(int page = 1, int pageSize = 10)
    {
        int count = (int)Math.Ceiling((double)(await _dbSet.CountAsync()));
        return new PaginationDataResult<TEntity>(count, page, pageSize, await _dbSet.Skip((page - 1) * pageSize)
                                                                                    .Take(pageSize)
                                                                                    .ToListAsync());
    }

    public async Task<PaginationDataResult<TEntity>> GetAll(int page = 1, int pageSize = 10, params string[] includableProperties)
    {
        int count = (int)Math.Ceiling((double)(await _dbSet.CountAsync()));
        return new PaginationDataResult<TEntity>(count, page, pageSize, await _dbSet.IncludeProperty(includableProperties)
                                                                                    .Skip((page - 1) * pageSize)
                                                                                    .Take(pageSize)
                                                                                    .ToListAsync());
    }

    public async Task<PaginationDataResult<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, int page = 1, int pageSize = 10)
    {
        int count = (int)Math.Ceiling((double)(await _dbSet.CountAsync(expression)));
        return new PaginationDataResult<TEntity>(count, page, pageSize, await _dbSet.Where(expression)
                                                                                    .Skip((page - 1) * pageSize)
                                                                                    .Take(pageSize)
                                                                                    .ToListAsync());
    }

    public async Task<PaginationDataResult<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, int page = 1, int pageSize = 10, params string[] includableProperties)
    {
        int count = (int)Math.Ceiling((double)(await _dbSet.CountAsync(expression)));
        return new PaginationDataResult<TEntity>(count, page, pageSize, await _dbSet.IncludeProperty(includableProperties)
                                                                                    .Where(expression)
                                                                                    .Skip((page - 1) * pageSize)
                                                                                    .Take(pageSize)
                                                                                    .ToListAsync());
    }

    public async Task<TEntity> GetById(int id)
    {
        return await _dbSet.SingleAsync(x => x.Id == id);
    }

    public async Task<TEntity> GetById(int id, params string[] includableProperties)
    {
        return await _dbSet.IncludeProperty(includableProperties).SingleAsync(x => x.Id == id);
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.SingleAsync(expression);
    }

    public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression, params string[] includableProperties)
    {
        return await _dbSet.IncludeProperty(includableProperties).SingleAsync(expression);
    }

    public async Task<TEntity> GetOrDefualt(Expression<Func<TEntity, bool>> expression)
    {
        return (await _dbSet.SingleOrDefaultAsync(expression))!;
    }

    public async Task<TEntity> GetOrDefualt(Expression<Func<TEntity, bool>> expression, params string[] includableProperties)
    {
        return (await _dbSet.IncludeProperty(includableProperties).SingleOrDefaultAsync(expression))!;
    }

    public async Task<decimal> Sum(Expression<Func<TEntity, decimal>> selector)
    {
        return await _dbSet.SumAsync(selector);
    }

    public async Task<decimal> Sum(Expression<Func<TEntity, decimal>> selector, Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.Where(expression).SumAsync(selector);
    }

    public async Task<long> Count()
    {
        return await _dbSet.CountAsync();
    }

    public async Task<long> Count(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.CountAsync(expression);
    }

    public async Task<bool> Any(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}