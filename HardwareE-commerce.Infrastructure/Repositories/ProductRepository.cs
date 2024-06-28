namespace HardwareE_commerce.Infrastructure;

public class ProductRepository : SqlBaseRepository<Product>, IProductRepository
{
    public ProductRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
