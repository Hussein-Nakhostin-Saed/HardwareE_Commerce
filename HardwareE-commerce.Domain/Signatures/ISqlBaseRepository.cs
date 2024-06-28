using System.Linq.Expressions;

namespace HardwareE_commerce.Domain;

public interface ISqlBaseRepository<TEntity> where TEntity : Entity
{
    Task Insert(TEntity entity);
    Task InsertMany(IEnumerable<TEntity> entities);
    Task Delete(int id);
    Task Delete(TEntity entity);
    Task DeleteMany(IEnumerable<int> ids);
    Task DeleteMany(IEnumerable<TEntity> entities);
    Task DeleteMany(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAll();
    Task<IEnumerable<TEntity>> GetAll(params string[] includableProperties);
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression);
    Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, params string[] includableProperties);
    Task<PaginationDataResult<TEntity>> GetAll(int page = 1, int pageSize = 10);
    Task<PaginationDataResult<TEntity>> GetAll(int page = 1, int pageSize = 10, params string[] includableProperties);
    Task<PaginationDataResult<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, int page = 1, int pageSize = 10);
    Task<PaginationDataResult<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, int page = 1, int pageSize = 10, params string[] includableProperties);
    Task<TEntity> GetById(int id);
    Task<TEntity> GetById(int id, params string[] includableProperties);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> Get(Expression<Func<TEntity, bool>> expression, params string[] includableProperties);
    Task<TEntity> GetOrDefualt(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetOrDefualt(Expression<Func<TEntity, bool>> expression, params string[] includableProperties);
    Task<decimal> Sum(Expression<Func<TEntity, decimal>> selector);
    Task<decimal> Sum(Expression<Func<TEntity, decimal>> selector, Expression<Func<TEntity, bool>> expression);
    Task<long> Count();
    Task<long> Count(Expression<Func<TEntity, bool>> expression = null);
    Task<bool> Any(Expression<Func<TEntity, bool>> expression);
    Task SaveChanges();
}
