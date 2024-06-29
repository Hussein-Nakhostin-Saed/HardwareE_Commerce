
namespace HardwareE_commerce.Validation;

public class PaymentSpecification : SpecificationBase<Payment>
{
    private readonly IPaymentRepository _paymentRepository;
    public PaymentSpecification(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }
    public override Expression<Func<Payment, bool>> SpecificationExpression
    {
        get
        {
            Expression<Func<Payment, bool>> spec = x => _paymentRepository.Any(c => c.OrderId.Equals(x.OrderId)).Result;

            return spec;
        }
    }
}
