namespace HardwareE_commerce.Infrastructure;

public class OrderRepository : SqlBaseRepository<Order>, IOrderRepository
{
    public OrderRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
