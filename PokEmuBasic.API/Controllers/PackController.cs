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

        [HttpPost("{packId}/open")]
        public async Task<IActionResult> OpenPackAsync([FromRoute] int packId)
        {
            var response = await _packService.OpenPackAsync(packId);

            return CreatedResponse(response, "Opened pack successfully");
        }
    }
}
