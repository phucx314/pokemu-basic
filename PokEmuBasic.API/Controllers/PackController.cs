using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokEmuBasic.Application.Services.Interfaces;

namespace PokEmuBasic.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/pack")]
    public class PackController : ApiController<PackController>
    {
        private readonly IPackService _packService;

        public PackController(
            IHttpContextAccessor httpContextAccessor,
            ICurrentUserContext currentUserContext,
            ILogger<PackController> logger,
            IAuthService authService,
            IPackService packService) : base(httpContextAccessor, currentUserContext, logger, authService)
        {
            _packService = packService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllPacks()
        {
            var response = await _packService.GetAllPacks();

            return OkResponse(response, "Get all packs successfully");
        }

        [HttpGet("list-available")]
        public async Task<IActionResult> GetAllAvailablePacks()
        {
            var response = await _packService.GetAllAvailablePacks();

            return OkResponse(response, "Get all available packs successfully");
        }

        [HttpGet("list-featured")]
        public async Task<IActionResult> GetFeaturedPacksAsync()
        {
            var response = await _packService.GetFeaturedPacksAsync();

            return OkResponse(response, "Get featured packs successfully");
        }

        [HttpPost("{packId}/open")]
        public async Task<IActionResult> OpenPackAsync([FromRoute] int packId)
        {
            var response = await _packService.OpenPackAsync(packId);

            return CreatedResponse(response, "Opened pack successfully");
        }
    }
}
