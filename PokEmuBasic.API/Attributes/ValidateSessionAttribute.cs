using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Application.Services.Interfaces;
using PokEmuBasic.Application.Dtos;

namespace PokEmuBasic.API.Attributes
{
    public class ValidateSessionAttribute : TypeFilterAttribute
    {
        public ValidateSessionAttribute() : base(typeof(ValidateSessionFilter))
        {
        }
    }

    public class ValidateSessionFilter : IAsyncActionFilter
    {
        private readonly IUserSessionRepository _sessionRepository;
        private readonly ICurrentUserContext _currentUserContext;

        public ValidateSessionFilter(IUserSessionRepository sessionRepository, ICurrentUserContext currentUserContext)
        {
            _sessionRepository = sessionRepository;
            _currentUserContext = currentUserContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var sessionId = _currentUserContext.SessionId;

            if (!sessionId.HasValue)
            {
                var response = new BaseResponse<object>
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Message = "Invalid token: Session ID is missing"
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };

                return;
            }

            var sessionIsValid = await _sessionRepository.SessionExistsAsync(sessionId.Value);

            if (!sessionIsValid)
            {
                var response = new BaseResponse<object>
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized,
                    Message = "Session is invalid, has been revoked, or has expired"
                };

                context.Result = new ObjectResult(response)
                {
                    StatusCode = (int)HttpStatusCode.Unauthorized
                };

                return;
            }

            //var userRole = _currentUserContext.UserRole;

            //if (userRole == Domain.Common.Enums.UserRole.BaseUser)
            //{
            //    var response = new BaseResponse<object>
            //    {
            //        StatusCode = (int)HttpStatusCode.Forbidden,
            //        Message = "Bro is not allowed to logout"
            //    };

            //    context.Result = new ObjectResult(response)
            //    {
            //        StatusCode = (int)HttpStatusCode.Forbidden
            //    };

            //    return;
            //}

            await next();
        }
    }
}
