using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokEmuBasic.Application.Dtos;
using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Application.Services.Interfaces;

namespace PokEmuBasic.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/card")]
    public class CardController : ApiController<CardController>
    {
        private readonly ICardService _cardService;

        public CardController(
            IHttpContextAccessor httpContextAccessor,
            ICurrentUserContext currentUserContext,
            ILogger<CardController> logger,
            IAuthService authService,
            ICardService cardService
        ) : base(httpContextAccessor, currentUserContext, logger, authService)
        {
            _cardService = cardService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetCardListByExpansionAsync([FromQuery] GetCardListRequest request)
        {
            var (res, total, expansionName) = await _cardService.GetCardListByExpansionAsync(request);

            var pagi = new PaginationMetadata(
                request.CurrentPage,
                25,
                total
            );

            return OkResponse(res, pagi, $"Get card lists of expansion '{expansionName}' successfully");
        }

        [HttpGet("owned/list")]
        public async Task<IActionResult> GetUserCardListByExpansionAsync([FromQuery] GetCardListRequest request)
        {
            var (res, total, expansionName) = await _cardService.GetUserCardListByExpansionAsync(request);

            var pagi = new PaginationMetadata(
                request.CurrentPage,
                25,
                total
            );

            return OkResponse(res, pagi, $"Get owned card lists of expansion '{expansionName}' successfully");
        }
    }
}
