namespace HardwareE_commerce.Domain;

[ObjectMapper]
public class SupportingMapper : Profile
{
    public SupportingMapper()
    {
        CreateMap<PaymentAddDto, Payment>();
        CreateMap<Payment, PaymentDto>();
        CreateMap<PaymentItem, PaymentItemDto>();
    }
}
