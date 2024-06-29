namespace HardwareE_commerce.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository, 
                        IMapper mapper, 
                        IProductRepository productRepository, 
                        ICardRepository cardRepository)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _productRepository = productRepository;
        _cardRepository = cardRepository;
    }

    public async Task InsertAsync(int cardId)
    {
        var card = await _cardRepository.GetById(cardId, "CardItems.Product");
        var totalAmount = card.CardItems.Select(x => x.Product.Price * x.Quantity).Sum();
        var order = new Order(card.TotalCount, totalAmount, card.UserId);
        var orderItems = card.CardItems.Select(x => new OrderItem(x.ProductId, x.Quantity, x.Product.Price * x.Quantity ));
        order.Items.AddRange(orderItems);

        await _orderRepository.Insert(order);
        await _orderRepository.SaveChanges();
    }

    public async Task InsertAsync(OrderItemAddDto dto, int userId)
    {
        var entity = _mapper.Map<OrderItem>(dto);
        entity.CreateAt = DateTime.Now;
        entity.DocumentState = DocumentState.Registered;

        var order = await _orderRepository.GetOrDefualt(x => x.UserId == userId &&
                                                        x.DocumentState != DocumentState.Draft &&
                                                        x.DocumentState != DocumentState.Deleted, "Product");
        if(order is not null)
        {
            order.DocumentState = DocumentState.Modified;
            order.ModifiedAt = DateTime.Now;
        }
        else
        {
            var totalAmount = entity.Quantity * entity.Product.Price;
            order = new Order(entity.Quantity, totalAmount, userId);
        }

        order.Items.Add(entity);

        await _orderRepository.Insert(order);
        await _orderRepository.SaveChanges();
    }

    public async Task<IEnumerable<OrderDto>> GetAllByUserAsync(int userId)
    {
        var entities = await _orderRepository.GetAll(x => x.DocumentState != DocumentState.Deleted && x.UserId == userId, "Items");
        var dtos = _mapper.MapCollection<Order, OrderDto>(entities);

        return dtos;
    }

    public async Task<IEnumerable<OrderDto>> GetAllAsync()
    {
        var entities = await _orderRepository.GetAll(x => x.DocumentState != DocumentState.Deleted, "Items");
        var dtos = _mapper.MapCollection<Order, OrderDto>(entities);

        return dtos;
    }
}
