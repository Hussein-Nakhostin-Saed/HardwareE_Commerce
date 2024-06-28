namespace HardwareE_commerce.Domain;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class ObjectMapperAttribute : Attribute
{
    public ObjectMapperAttribute()
    {
    }
}
