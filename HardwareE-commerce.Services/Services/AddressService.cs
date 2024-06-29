namespace HardwareE_commerce.Services;

public class AddressService : ServiceBase<AddressAddDto, AddressEditDto, AddressDto, Address>
{
    private readonly IAddressRepository _repository;
    private readonly IMapper _mapper;
    public AddressService(IAddressRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AddressDto>> GetAllByUserAsync(int userId)
    {
        var entities = await _repository.GetAll(x => x.DocumentState != DocumentState.Deleted && x.UserId == userId);
        var dtos = _mapper.MapCollection<Address, AddressDto>(entities);

        return dtos;
    }
}
