namespace HardwareE_commerce.Domain;

public class Category : MutableEntity
{
    public string Name { get; set; }
    public int? ParentId { get; set; }
    public Category? Parent { get; set; }

    public Category()
    {
    }
}
