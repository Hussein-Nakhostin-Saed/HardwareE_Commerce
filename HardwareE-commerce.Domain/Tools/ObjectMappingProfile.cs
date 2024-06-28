using System.Reflection;

namespace HardwareE_commerce.Domain;

public class ObjectMappingProfile
{
    public ObjectMappingProfile()
    {
        var startAssName = "HardwareE-commerce";
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        if (!string.IsNullOrEmpty(startAssName))
        {
            assemblies = assemblies.Where((Assembly x) => x.GetName().FullName.StartsWith(startAssName)).ToArray();
        }

        var types = assemblies.SelectMany(x => x.GetTypes());
        foreach (var type in types)
        {
            var attr = type.GetCustomAttribute<ObjectMapperAttribute>(false);
            if (attr != null)
            {
                Activator.CreateInstance(type, this);
            }
        }
    }
}
