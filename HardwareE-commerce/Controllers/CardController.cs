using Microsoft.AspNetCore.Mvc;

namespace HardwareE_commerce.Controllers;

[Route("api/card")]
[ApiController]
public class CardController : BaseController<CardAddDto, CardEditDto, CardDto, Card>
{
    public CardController(CardService cardService) : base(cardService)
    {
    }

    [Authorization(PermissionSignatures.CanEditCard)]
    [Route("")]
    [HttpPost]
    public override Task InsertAsync(CardAddDto dto) => base.InsertAsync(dto);

    [Authorization(PermissionSignatures.CanEditCard)]
    [Route("")]
    [HttpPut]
    public override Task UpdateAsync(CardEditDto dto) => base.UpdateAsync(dto);

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
    public override Task<IEnumerable<CardDto>> GetAllAsync() => base.GetAllAsync();

    [Authorization(PermissionSignatures.CardView)]
    [Route("all/pagination")]
    [HttpGet]
    public override Task<PagableListDtoBase<CardDto>> GetAllPageable(PagableListDtoBase<CardDto> dto) => base.GetAllPageable(dto);

}
