namespace HardwareE_commerce.Validation;

public abstract class SpecificationBase<T> : ISpecification<T>
{
    private Func<T, bool> _compiledExpression;
    private Func<T, bool> CompiledExpression
    {
        get
        {
            return _compiledExpression ?? (_compiledExpression = SpecificationExpression.Compile());
        }
    }
    public abstract Expression<Func<T, bool>> SpecificationExpression { get; }

    public bool IsSatisfied(T obj)
    {
        return CompiledExpression(obj);
    }
}
