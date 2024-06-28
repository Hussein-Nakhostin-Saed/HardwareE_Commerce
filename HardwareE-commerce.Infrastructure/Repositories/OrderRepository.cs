namespace HardwareE_commerce.Infrastructure;

public class OrderRepository : SqlBaseRepository<Product>, IOrderRepository
{
    public OrderRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
