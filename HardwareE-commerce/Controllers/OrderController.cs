using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController : SecureBaseController
{
    private readonly OrderService _orderService;
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [Authorization(PermissionSignatures.CanEditCategory)]
    [Route("")]
    [HttpPost]
    public Task InsertAsync(OrderItemAddDto dto) => _orderService.InsertAsync(dto, UserContext.UserId);

    [Authorization(PermissionSignatures.CanEditCategory)]
    [Route("bycard/{cardid}")]
    [HttpPost]
    public Task InsertAsync(int cardid) => _orderService.InsertAsync(cardid);

    [Authorization(PermissionSignatures.CategoryView)]
    [Route("")]
    [HttpGet]
    public async Task<IEnumerable<OrderDto>> GetAllAsync() => await _orderService.GetAllAsync();

    [Authorization(PermissionSignatures.CategoryView)]
    [Route("user/all")]
    [HttpGet]
    public async Task<IEnumerable<OrderDto>> GetAllByUserAsync() => await _orderService.GetAllByUserAsync(UserContext.UserId);
}
