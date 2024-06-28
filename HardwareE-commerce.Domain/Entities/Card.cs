namespace HardwareE_commerce.Domain;

public class Card : MutableEntity
{
    public int TotalCount { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public ICollection<CardItem> CardItems { get; set; }

    public Card()
    {
        
    }
}
