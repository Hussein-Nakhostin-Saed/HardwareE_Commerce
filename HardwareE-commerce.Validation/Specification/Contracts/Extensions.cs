namespace HardwareE_commerce.Validation;

public static class Extensions
{
    public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right) where T : Entity
    {
        return new And<T>(left, right);
    }

    public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right) where T : Entity
    {
        return new Or<T>(left, right);
    }

    public static ISpecification<T> Negate<T>(this ISpecification<T> specification) where T : Entity
    {
        return new Negate<T>(specification);
    }
}
