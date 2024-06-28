namespace HardwareE_commerce.Domain;

public class Permission : Entity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public IEnumerable<Role> Roles { get; set; }

    public Permission()
    {
    }
    public Permission(int id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }
}
