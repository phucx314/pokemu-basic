using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using PokEmuBasic.API.Attributes;
using PokEmuBasic.Infrastructure.Settings;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Data;
using PokEmuBasic.Application.Dtos;

namespace PokEmuBasic.API.IOC
{
    public static partial class DI
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            // ---------- Add Swagger config here ----------
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {your_token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // Load TokenSettings from configuration  
            var tokenSettings = new TokenSettings();
            configuration.GetSection("TokenSettings").Bind(tokenSettings);

            // Configure JWT Authentication  
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = tokenSettings.Issuer,
                    ValidAudience = tokenSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(tokenSettings.SecretKey)),
                    ClockSkew = TimeSpan.Zero // Disable the default 5-minute tolerance
                };
            });

            // policy config
            //services.AddAuthorizationBuilder()
            //    // Chính sách 1: Ai được làm những việc của BaseUser?
            //    // Bất kỳ ai đã đăng nhập và có vai trò BaseUser, HOẶC SuperUser, HOẶC Admin đều thỏa mãn.
            //    .AddPolicy("CanDoBaseUserStuff", policy => policy.RequireRole(UserRole.BaseUser.ToString(), UserRole.SuperUser.ToString(), UserRole.Admin.ToString()))

            //    // Chính sách 2: Ai được làm những việc của SuperUser?
            //    // Những người có vai trò SuperUser HOẶC Admin sẽ thỏa mãn.
            //    .AddPolicy("CanDoSuperUserStuff", policy => policy.RequireRole(UserRole.SuperUser.ToString(), UserRole.Admin.ToString()))

            //    // Chính sách 3: Ai được làm những việc của Admin?
            //    // Chỉ những người có vai trò Admin.
            //    .AddPolicy("IsAdmin", policy => policy.RequireRole(UserRole.Admin.ToString()));

            // 
            services.AddScoped<ValidateSessionFilter>();

            return services;
        }

        public static IServiceCollection AddEndpointConfig(this IServiceCollection services)
        {
            // ---------- Add Endpoint config here ----------
            services.AddEndpointsApiExplorer();

            return services;
        }

        public static IServiceCollection AddCorsConfig(this IServiceCollection services)
        {
            // ---------- Add CORS config here ----------
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }

        public static IServiceCollection AddControllerConfig(this IServiceCollection services)
        {
            // ---------- Add Controller config here ----------
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreReadOnlyFields = true;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            return services;
        }

        public static IServiceCollection AddModelStateValidationConfig(this IServiceCollection services)
        {
            // ---------- Add Controller config here ----------
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState
                        .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    var response = new BaseResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Errors = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });

            return services;
        }
    }
}
