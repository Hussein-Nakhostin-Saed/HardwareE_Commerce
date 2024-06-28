namespace HardwareE_commerce.Validation;

public class Negate<T> : SpecificationBase<T> where T : Entity
{
    private readonly ISpecification<T> _specification;
    public Negate(ISpecification<T> specification)
    {
        _specification = specification;
    }

    public override Expression<Func<T, bool>> SpecificationExpression
    {
        get
        {
            var parameter = Expression.Parameter(typeof(T), "obj");

            return Expression.Lambda<Func<T, bool>>
                (Expression.Not(
                    Expression.Invoke(_specification.SpecificationExpression, parameter)), parameter);
        }
    }
}
