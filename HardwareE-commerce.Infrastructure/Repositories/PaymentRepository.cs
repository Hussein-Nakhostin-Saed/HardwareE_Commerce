namespace HardwareE_commerce.Infrastructure;

public class PaymentRepository : SqlBaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
