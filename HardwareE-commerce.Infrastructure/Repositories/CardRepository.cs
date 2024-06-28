namespace HardwareE_commerce.Infrastructure;

public class CardRepository : SqlBaseRepository<Card>, ICardRepository
{
    public CardRepository(E_CommerceContext dbContext) : base(dbContext)
    {
    }
}
