using PokEmuBasic.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PokEmuBasic.Application.Services
{
    public class CurrentUserContext : ICurrentUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId
        {
            get
            {
                var userIdString = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
                return userIdString != null ? int.Parse(userIdString) : null;
            }
        }

        public int? SessionId
        {
            get
            {
                var sessionIdString = _httpContextAccessor.HttpContext?.User.FindFirstValue("sid");
                return sessionIdString != null ? int.Parse(sessionIdString) : null;
            }
        }
    }
}
