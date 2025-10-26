using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokEmuBasic.API.Attributes;
using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Application.Services.Interfaces;

namespace PokEmuBasic.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ApiController<AuthController>
    {
        private readonly IMapper _mapper;
        public AuthController(
            IHttpContextAccessor httpContextAccessor,
            ICurrentUserContext currentUserContext,
            ILogger<AuthController> logger,
            IAuthService authService,
            IMapper mapper) : base(httpContextAccessor, currentUserContext, logger, authService)
        {
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterNewUserRequest registerNewUserRequest)
        {
            await _authService.RegisterAsync(registerNewUserRequest);

            return OkResponse("Registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Application.Dtos.Requests.LoginRequest loginRequest)
        {
            var data = await _authService.LoginAsync(loginRequest);

            return OkResponse(data, "Logged in successfully");
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> GenerateRefreshToken([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var data = await _authService.RefreshTokenAsync(refreshTokenRequest);

            return OkResponse(data, "Tokens refreshed");
        }

        [HttpGet("me")] // TODO: cần sửa ko show hash pass
        [Authorize]
        [ValidateSession]
        public async Task<IActionResult> GetMyInfo()
        {
            var user = await GetCurrentUserAsync();

            var processedData = _mapper.Map<GetMe>(user);

            return OkResponse(processedData, "User info retrieved successfully");
        }

        [HttpPost("logout")]
        [Authorize]
        [ValidateSession]
        public async Task<IActionResult> Logout()
        {
            var sessionId = _currentUserContext.SessionId;

            if (sessionId.HasValue)
            {
                await _authService.LogoutAsync(sessionId.Value);
            }

            return OkResponse("Logged out");
        }

        //[HttpDelete("clean-up")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> CleanUpDatabase()
        //{
        //    await _authService.CleanUpDatabase();

        //    return OkResponse("Cleaned up revoked sessions");
        //}
    }
}
