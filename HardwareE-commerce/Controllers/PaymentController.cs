using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/payment")]
[ApiController]
public class PaymentController : SecureBaseController
{
    private readonly PaymentService _paymentService;
    public PaymentController(PaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [Authorization(PermissionSignatures.CanEditPayment)]
    [Route("")]
    [HttpPost]
    public async Task InsertAsync(int orderId) => await _paymentService.InsertAsync(orderId);

    [Authorization(PermissionSignatures.PaymentView)]
    [Route("user/all")]
    [HttpGet]
    public async Task<IEnumerable<PaymentDto>> GetAllByUserAsync() => await _paymentService.GetAllByUserAsync(UserContext.UserId);

    [Authorization(PermissionSignatures.PaymentView)]
    [Route("all")]
    [HttpGet]
    public async Task<IEnumerable<PaymentDto>> GetAllAsync() => await _paymentService.GetAllAsync();

    [Authorization(PermissionSignatures.PaymentView)]
    [Route("user-payment")]
    [HttpGet]
    public async Task<PaymentDto> GetPaymentAsync() => await _paymentService.GetPayment(UserContext.UserId);
}
