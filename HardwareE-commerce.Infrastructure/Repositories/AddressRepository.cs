namespace HardwareE_commerce.Infrastructure;

public class AddressRepository : SqlBaseRepository<Address>, IAddressRepository
{
    public AddressRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
