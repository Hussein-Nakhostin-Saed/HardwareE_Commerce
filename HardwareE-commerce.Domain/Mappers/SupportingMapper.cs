namespace HardwareE_commerce.Domain;

[ObjectMapper]
public class SupportingMapper : Profile
{
    public SupportingMapper()
    {
        CreateMap<Payment, PaymentDto>();
    }
}
