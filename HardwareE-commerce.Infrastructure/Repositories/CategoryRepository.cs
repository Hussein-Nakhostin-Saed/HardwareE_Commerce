namespace HardwareE_commerce.Infrastructure;

public class CategoryRepository : SqlBaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
