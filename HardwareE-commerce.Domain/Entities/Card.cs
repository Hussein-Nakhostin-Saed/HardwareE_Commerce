using System.Collections.ObjectModel;

namespace HardwareE_commerce.Domain;

public class Card : MutableEntity
{
    public int TotalCount { get; set; }
    public User User { get; set; }
    public int UserId { get; set; }
    public ICollection<CardItem> CardItems { get; set; }

    public Card(int totalCount, int userId)
    {
        TotalCount = totalCount;
        UserId = userId;
        CardItems = new Collection<CardItem>();
    }
}
