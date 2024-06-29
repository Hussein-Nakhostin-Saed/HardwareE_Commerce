namespace HardwareE_commerce.Services;

public class CardService : ServiceBase<CardItemAddDto, CardItemEditDto, CardDto, Card>
{
    private readonly ICardRepository _repository;
    private readonly IMapper _mapper;
    public CardService(ICardRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task InsertAsync(CardItemAddDto dto, int userId)
    {
        var userCard = await _repository.GetOrDefualt(x => x.UserId == userId &&
                                                      x.DocumentState != DocumentState.Draft &&
                                                      x.DocumentState != DocumentState.Deleted);

        var entity = _mapper.Map<CardItem>(dto);
        entity.CreateAt = DateTime.Now;
        entity.DocumentState = DocumentState.Registered;

        if (userCard is not null)
        {
            userCard.DocumentState = DocumentState.Modified;
            userCard.CardItems.Add(entity);
            userCard.TotalCount += entity.Quantity;

            await _repository.SaveChanges();
        }
        else
        {
            userCard = new Card(entity.Quantity, userId);
            userCard.CreateAt = DateTime.Now;
            userCard.DocumentState = DocumentState.Registered;
            userCard.CardItems.Add(entity);

            await _repository.Insert(userCard);
            await _repository.SaveChanges();
        }
    }

    public override async Task UpdateAsync(CardItemEditDto dto)
    {
        var entity = (await _repository.GetById(dto.Id, "CardItems")).CardItems.Single(x => x.ProductId == dto.ProductId);
        _mapper.Map(dto, entity);
        entity.ModifiedAt = DateTime.Now;
        entity.DocumentState = DocumentState.Modified;

        await _repository.SaveChanges();
    }

    public async Task SoftDeleteAsync(int id)
    {
        var entity = await _repository.GetById(id);
        entity.DeletedAt = DateTime.Now;
        entity.DocumentState = DocumentState.Deleted;

        await _repository.SaveChanges();
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.Delete(id);
    }

    public async Task<IEnumerable<CardDto>> GetAllByUserAsync(int userId)
    {
        var entities = await _repository.GetAll(x => x.DocumentState != DocumentState.Deleted && x.UserId == userId, "CardItems");
        var dtos = _mapper.MapCollection<Card, CardDto>(entities);

        return dtos;
    }

    public async Task<IEnumerable<CardDto>> GetAllAsync()
    {
        var entities = await _repository.GetAll(x => x.DocumentState != DocumentState.Deleted, "CardItems");
        var dtos = _mapper.MapCollection<Card, CardDto>(entities);

        return dtos;
    }
}
