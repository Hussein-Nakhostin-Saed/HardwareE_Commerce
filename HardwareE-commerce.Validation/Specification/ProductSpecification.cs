
namespace HardwareE_commerce.Validation;

public class ProductSpecification : SpecificationBase<Product>
{
    private readonly IProductRepository _repository;
    public ProductSpecification(IProductRepository repository)
    {
        _repository = repository;
    }

    public override Expression<Func<Product, bool>> SpecificationExpression
    {
        get
        {
            Expression<Func<Product, bool>> spec = x => !x.Equals(_repository.GetOrDefualt(c => c.BarCode.Equals(x.BarCode)).Result);

            return spec;
        }
    }
}
