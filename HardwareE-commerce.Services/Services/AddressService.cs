namespace HardwareE_commerce.Services;

public class AddressService : ServiceBase<AddressAddDto, AddressEditDto, AddressDto, Address>
{
    public AddressService(IAddressRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
