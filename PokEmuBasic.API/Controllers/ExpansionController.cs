using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokEmuBasic.Application.Dtos;
using PokEmuBasic.Application.Dtos.Requests;
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
        public async Task<IActionResult> GetExpansionOptionsAsync([FromQuery] GetExpansionOptionsRequest request)
        {
            // get raw data from service
            var (res, total) = await _expansionService.GetExpansionOptionsAsync(request);

            // map pagination metadata tai controller
            var paginationMetadata = new PaginationMetadata(
                request.CurrentPage,
                request.PageSize,
                total
            );

            return OkResponse(res, paginationMetadata, "Get expansion options successfully");
        }
    }
}
