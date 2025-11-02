using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokEmuBasic.Application.Dtos.Requests;
using PokEmuBasic.Application.Dtos.Responses;
using PokEmuBasic.Application.Exceptions;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Application.Services.Interfaces;
using PokEmuBasic.Domain.Entities;
using PokEmuBasic.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IUserSessionRepository _userSessionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthService(
            ITokenService tokenService,
            IUserRepository userRepository,
            IUserSessionRepository userSessionRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _userSessionRepository = userSessionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.HashedPassword))
            {
                throw new UnAuthorizedException("Invalid email/username or password");
            }

            return await CreateAndSaveTokensAsync(user, request.DeviceName, request.IpAddress);
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var session = await _userSessionRepository.GetByRefreshTokenAsync(request.RefreshToken);

            if (session == null || session.IsRevoked || session.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                throw new UnAuthorizedException("Invalid or expired refresh token");
            }

            session.IsRevoked = true;
            session.RevokedAt = DateTime.UtcNow;

            await _userSessionRepository.Update(session);
            await _unitOfWork.SaveChangesAsync();

            return await CreateAndSaveTokensAsync(session.User, session.DeviceName, session.IpAddress);
            // TODO: check lai phan nay (ko update devicename va ipaddress ma lay cai cũ) #311025
        }

        private async Task<LoginResponse> CreateAndSaveTokensAsync(User user, string? deviceName, string? ipAddress)
        {
            // tao 1 session moi trong bo nho
            var newSession = new UserSession
            {
                UserId = user.Id,
                RefreshToken = _tokenService.GenerateRefreshToken(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7),
                DeviceName = deviceName,
                IpAddress = ipAddress,
                CreatedAt = DateTime.UtcNow,
                IsRevoked = false
            };

            // luu session xuong database TRUOC
            await _userSessionRepository.AddAsync(newSession);
            await _unitOfWork.SaveChangesAsync();

            // BAY GIO moi dung id của session da duoc luu de tao access token
            var accessToken = await _tokenService.CreateToken(user, newSession.Id);

            var authInfo = _mapper.Map<GetMe>(user);

            return new LoginResponse
            {
                AccessToken = accessToken,
                ExpiresAt = DateTime.UtcNow.AddHours(1),
                RefreshToken = newSession.RefreshToken,
                AuthInfo = authInfo
            };
        }

        public async Task<User> RegisterAsync(RegisterNewUserRequest registerNewUserRequest)
        {
            var existingUser = await _userRepository.ExistsUsernameAsync(registerNewUserRequest.Username);

            if (existingUser)
            {
                throw new DuplicateException("Username or Email already exists");
            }

            var user = new User
            {
                FullName = registerNewUserRequest.FullName,
                Username = registerNewUserRequest.Username,
                HashedPassword = BCrypt.Net.BCrypt.HashPassword(registerNewUserRequest.Password),
                CoinBalance = 1000
            };

            await _userRepository.AddAsync(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();

            return user;
        }

        public async Task<User?> GetCurrentUserAsync(int id)
        {
            return await _userRepository
                .Queryable
                .WithoutDeleted()
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task LogoutAsync(int sessionId)
        {

            var session = await _userSessionRepository.GetByIdAsync(sessionId);

            if (session == null)
            {
                throw new NotFoundException("Session not found");
            }

            session.IsRevoked = true;
            session.RevokedAt = DateTime.UtcNow;

            await _userSessionRepository.Update(session);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CleanUpDatabase()
        {
            var revokedSessions = await _userSessionRepository.Queryable
                .Where(us => us.IsRevoked == true && us.RefreshTokenExpiryTime < DateTime.UtcNow)
                .ToListAsync();

            await _userSessionRepository.DeleteRange(revokedSessions);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
