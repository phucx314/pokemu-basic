using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokEmuBasic.Application.Services.Interfaces;

namespace PokEmuBasic.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/expansion")]
    public class ExpansionController : ApiController<ExpansionController>
    {
        private readonly IExpansionService _expansionService;

        public ExpansionController(
            IHttpContextAccessor httpContextAccessor,
            ICurrentUserContext currentUserContext,
            ILogger<ExpansionController> logger,
            IAuthService authService,
            IExpansionService expansionService
        ) : base(httpContextAccessor, currentUserContext, logger, authService)
        {
            _expansionService = expansionService;
        }

        [HttpGet("options")]
        public async Task<IActionResult> GetExpansionOptionsAsync()
        {
            var res = await _expansionService.GetExpansionOptionsAsync();

            return OkResponse(res, "Get expansion options successfully");
        }
    }
}
