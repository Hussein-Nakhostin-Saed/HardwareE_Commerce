namespace HardwareE_commerce.Validation;
public class Or<T> : SpecificationBase<T> where T : Entity
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;
    public Or(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> SpecificationExpression
    {
        get
        {
            var parameter = Expression.Parameter(typeof(T), "obj");

            return Expression.Lambda<Func<T, bool>>
                (Expression.Or(
                    Expression.Invoke(_left.SpecificationExpression, parameter),
                    Expression.Invoke(_right.SpecificationExpression, parameter)), parameter);
        }
    }
}
