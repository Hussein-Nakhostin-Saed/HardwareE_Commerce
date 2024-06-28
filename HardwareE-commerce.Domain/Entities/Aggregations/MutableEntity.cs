namespace HardwareE_commerce.Domain;

public class MutableEntity : Entity
{
    public DocumentState DocumentState { get; set; }
    public DateTime ModifiedAt { get; set; }
    public DateTime DeletedAt { get; set; }
}
