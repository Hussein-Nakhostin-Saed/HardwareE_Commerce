using HardwareE_commerce.Validation;

namespace HardwareE_commerce.Services;

public class ProductService : ServiceBase<ProductAddDto, ProductEditDto, ProductDto, Product>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly ProductSpecification _productSpecification;
    public ProductService(IProductRepository repository, IMapper mapper, ProductSpecification productSpecification) : base(repository, mapper)
    {
        _productRepository = repository;
        _mapper = mapper;
        _productSpecification = productSpecification;
    }

    public override async Task InsertAsync(ProductAddDto dto)
    {
        var entity = _mapper.Map<Product>(dto);

        if (_productSpecification.IsSatisfied(entity))
            throw new Exception("Invalid Product");

        entity.CreateAt = DateTime.Now;
        entity.DocumentState = DocumentState.Registered;

        await _productRepository.Insert(entity);
        await _productRepository.SaveChanges();
    }
}
