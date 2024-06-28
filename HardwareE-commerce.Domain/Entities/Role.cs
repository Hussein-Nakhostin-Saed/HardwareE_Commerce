namespace HardwareE_commerce.Domain;

public class Role : MutableEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public ICollection<Permission> Permissions { get; set; }
    public ICollection<User> Users { get; set; }

    public Role(int id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
    }
}
