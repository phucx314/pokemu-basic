using Microsoft.AspNetCore.Mvc;
using PokEmuBasic.Application.Dtos;
using PokEmuBasic.Application.Exceptions;
using PokEmuBasic.Application.Services.Interfaces;
using PokEmuBasic.Domain.Entities;
using System.Net;
using System.Security.Claims;

namespace PokEmuBasic.API.Controllers
{
    [ApiController]
    public abstract class ApiController<T> : ControllerBase where T : class
    {
        protected readonly ILogger _logger;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICurrentUserContext _currentUserContext;
        protected readonly IAuthService _authService;

        protected ApiController(
            IHttpContextAccessor httpContextAccessor,
            ICurrentUserContext currentUserContext,
            ILogger<T> logger,
            IAuthService authService)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _currentUserContext = currentUserContext ?? throw new ArgumentException(nameof(currentUserContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        protected async Task<User> GetCurrentUserAsync()
        {
            var httpContext = _httpContextAccessor.HttpContext ?? throw new UnAuthorizedException("HttpContext is null");

            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new UnAuthorizedException("Not found user id");

            var user = await _authService.GetCurrentUserAsync(int.Parse(userId)) ?? throw new UnAuthorizedException("User not found");

            if (user.IsDeleted)
            {
                throw new UnAuthorizedException("Your account has been deleted");
            }

            return user;
        }

        /// <summary>
        /// Trả về một kết quả 200 OK với dữ liệu và thông điệp.
        /// </summary>
        protected ActionResult OkResponse<TData>(TData data, string? message = "Success") where TData : class
        {
            var response = new BaseResponse<TData>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = data,
                Message = message
            };
            return Ok(response);
        }

        /// <summary>
        /// Trả về một kết quả 200 OK với dữ liệu và thông tin phân trang.
        /// </summary>
        protected ActionResult OkResponse<TData>(TData data, PaginationMetadata paginationMetadata, string? message = "Success") where TData : class
        {
            var response = new BaseResponse<TData>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Data = data,
                Message = message,
                PaginationMetadata = paginationMetadata
            };
            return Ok(response);
        }

        /// <summary>
        /// Trả về một kết quả 200 OK chỉ với thông điệp (khi không có dữ liệu).
        /// </summary>
        protected ActionResult OkResponse(string? message = "Success")
        {
            var response = new BaseResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = message
            };
            return Ok(response);
        }

        /// <summary>
        /// Trả về một kết quả 400 Bad Request với cấu trúc lỗi chi tiết.
        /// </summary>
        protected ActionResult BadRequestResponse(IDictionary<string, string[]> validationErrors)
        {
            var response = new BaseResponse
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                Message = "One or more validation errors occurred.",
                Errors = validationErrors
            };
            return BadRequest(response);
        }

        /// <summary>
        /// Trả về một kết quả lỗi với mã status và thông điệp tùy chỉnh.
        /// </summary>
        protected ActionResult ErrorResponse(int statusCode, string message)
        {
            var response = new BaseResponse
            {
                StatusCode = statusCode,
                Message = message
            };
            return StatusCode(statusCode, response);
        }

        /// <summary>
        /// Trả về một kết quả 404 Not Found.
        /// </summary>
        protected ActionResult NotFoundResponse(string message = "Resource not found")
        {
            return ErrorResponse((int)HttpStatusCode.NotFound, message);
        }

        /// <summary>
        /// Trả về một kết quả 403 Forbidden (Không có quyền).
        /// </summary>
        protected ActionResult ForbiddenResponse(string message = "You do not have permission to access this resource")
        {
            return ErrorResponse((int)HttpStatusCode.Forbidden, message);
        }

        /// <summary>
        /// Trả về một kết quả 401 Unauthorized (Chưa xác thực).
        /// </summary>
        protected ActionResult UnauthorizedResponse(string message = "Authentication failed")
        {
            return ErrorResponse((int)HttpStatusCode.Unauthorized, message);
        }

        /// <summary>
        /// Trả về một kết quả 500 Internal Server Error.
        /// </summary>
        protected ActionResult InternalServerErrorResponse(string message = "An unexpected error occurred")
        {
            return ErrorResponse((int)HttpStatusCode.InternalServerError, message);
        }

        protected ActionResult CreatedResponse(string? message = null)
        {
            var response = new BaseResponse<object>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Message = message
            };

            return StatusCode((int)HttpStatusCode.Created, response);
        }

        protected ActionResult CreatedResponse<TData>(TData data, string? message = null)
        {
            var response = new BaseResponse<object>
            {
                StatusCode = (int)HttpStatusCode.Created,
                Message = message,
                Data = data
            };

            return StatusCode((int)HttpStatusCode.Created, response);
        }
    }
}
