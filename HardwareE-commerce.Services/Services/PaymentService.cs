using HardwareE_commerce.Validation;

namespace HardwareE_commerce.Services;

public class PaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly ICardRepository _cardRepository;
    private readonly PaymentSpecification _paymentSpecification;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public PaymentService(IPaymentRepository paymentRepository, 
                          IMapper mapper, 
                          IOrderRepository orderRepository, 
                          ICardRepository cardRepository, 
                          PaymentSpecification paymentSpecification,
                          IProductRepository productRepository)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
        _orderRepository = orderRepository;
        _cardRepository = cardRepository;
        _paymentSpecification = paymentSpecification;
        _productRepository = productRepository;
    }

    public async Task InsertAsync(int orderId)
    {
        var order = await _orderRepository.GetById(orderId, "Items");
        var payment = new Payment(order.TotalAmount, order.Id);

        if (_paymentSpecification.IsSatisfied(payment))
            throw new Exception("Invalid Payment");

        var paymentItems = order.Items.Select(x => new PaymentItem(x.TotalAmount, x.Id));
        payment.Items.AddRange(paymentItems);

        order.DocumentState = DocumentState.Draft;

        await CloseCard(order);

        await ProductQuantityLoser(paymentItems.Select(x => x.OrderItemId), order);

        await _paymentRepository.Insert(payment);
        await _paymentRepository.SaveChanges();
    }

    public async Task<IEnumerable<PaymentDto>> GetAllByUserAsync(int userId)
    {
        var orders = (await _orderRepository.GetAll(x => x.DocumentState != DocumentState.Deleted
                                                     && x.DocumentState != DocumentState.Draft && x.UserId == userId)).Select(x => x.Id);

        var entities = await _paymentRepository.GetAll(x => x.DocumentState != DocumentState.Deleted
                                                     && x.DocumentState != DocumentState.Draft && orders.Contains(x.OrderId), "Items");

        //بخاطر باگ سیستمی خودم نمی تونستم از کوئری پایین خروجی بگیرم
        //var entities = await _paymentRepository.GetAll(x => x.DocumentState != DocumentState.Deleted && x.Order.UserId == userId, "Items");
        var dtos = _mapper.MapCollection<Payment, PaymentDto>(entities);

        return dtos;
    }

    public async Task<IEnumerable<PaymentDto>> GetAllAsync()
    {
        var entities = await _paymentRepository.GetAll(x => x.DocumentState != DocumentState.Deleted, "Items");
        var dtos = _mapper.MapCollection<Payment, PaymentDto>(entities);

        return dtos;
    }

    public async Task<PaymentDto> GetPayment(int userId)
    {
        var order = await _orderRepository.GetOrDefualt(x => x.DocumentState != DocumentState.Deleted
                                                     && x.DocumentState != DocumentState.Draft && x.UserId == userId);

        var entity = await _paymentRepository.GetOrDefualt(x => x.DocumentState != DocumentState.Deleted
                                                     && x.DocumentState != DocumentState.Draft && x.OrderId == order.Id, "Items");

        //بخاطر باگ سیستمی خودم نمی تونستم از کوئری پایین خروجی بگیرم
        //var entity = await _paymentRepository.GetOrDefualt(x => x.Order.UserId == userId, "Items");
        var dtos = _mapper.Map<Payment, PaymentDto>(entity);

        return dtos;
    }

    private async Task ProductQuantityLoser(IEnumerable<int> orderItemIds, Order order)
    {
        var product = await _productRepository.GetAll(x => orderItemIds.Contains(x.Id));
        foreach (var item in product)
            item.Quantity -= order.TotalCount;
    }

    private async Task CloseCard(Order order)
    {
        var card = await _cardRepository.Get(x => x.UserId == order.UserId &&
                                             x.DocumentState != DocumentState.Draft &&
                                             x.DocumentState != DocumentState.Deleted);

        card.DocumentState = DocumentState.Draft;
    }
}
