using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User?> GetCurrentUserAsync(int id);
        Task<User> RegisterAsync(RegisterNewUserRequest registerNewUserRequest);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request);
        Task LogoutAsync(int sessionId);
        Task CleanUpDatabase();
    }
}
