namespace HardwareE_commerce.Validation;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> SpecificationExpression { get; }
    bool IsSatisfied(T obj);
}
