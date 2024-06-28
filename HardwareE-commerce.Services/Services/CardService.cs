
namespace HardwareE_commerce.Services;

public class CardService : ServiceBase<CardAddDto, CardEditDto, CardDto, Card>
{
    public CardService(ICardRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
