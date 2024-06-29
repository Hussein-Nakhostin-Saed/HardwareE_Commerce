using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/card")]
[ApiController]
public class CardController : BaseController<CardItemAddDto, CardItemEditDto, CardDto, Card>
{
    private readonly CardService _cardService;
    public CardController(CardService cardService) : base(cardService)
    {
        _cardService = cardService;
    }

    [Authorization(PermissionSignatures.UserCanEditCard)]
    [Route("")]
    [HttpPost]
    public override Task InsertAsync(CardItemAddDto dto) => _cardService.InsertAsync(dto, UserContext.UserId);

    [Authorization(PermissionSignatures.CanEditCard)]
    [Route("")]
    [HttpPut]
    public override Task UpdateAsync(CardItemEditDto dto) => base.UpdateAsync(dto);

    [Authorization(PermissionSignatures.CanEditCard)]
    [Route("")]
    [HttpDelete]
    public override Task DeleteAsync(int id) => base.DeleteAsync(id);

    [Authorization(PermissionSignatures.CanEditCard)]
    [Route("delete/soft")]
    [HttpDelete]
    public override Task SoftDeleteAsync(int id) => base.SoftDeleteAsync(id);

    [Authorization(PermissionSignatures.CardView)]
    [Route("")]
    [HttpGet]
    public override async Task<IEnumerable<CardDto>> GetAllAsync() => await _cardService.GetAllAsync();

    [Authorization(PermissionSignatures.CardUserView)]
    [Route("user/all")]
    [HttpGet]
    public async Task<IEnumerable<CardDto>> GetAllByUserAsync() => await _cardService.GetAllByUserAsync(UserContext.UserId);
}
