using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PokEmuBasic.Application.Repositories;
using PokEmuBasic.Application.Services.Interfaces;
using PokEmuBasic.Infrastructure.Database;
using PokEmuBasic.Infrastructure.Repositories;
using PokEmuBasic.Infrastructure.Services;
using PokEmuBasic.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.IOC
{
    public partial class Program { }
    public static partial class DI
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // ---------- Add Repositories here ----------
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPackRepository, PackRepository>();
            services.AddScoped<IExpansionRepository, ExpansionRepository>();
            services.AddScoped<IUserCardRepository, UserCardRepository>();
            services.AddScoped<IUserSessionRepository, UserSessionRepository>();
            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<DatabaseContext>());

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var logger = services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

            // ---------- Add Infrastructure here ----------
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContext>(options => options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());

            services.Configure<TokenSettings>(configuration.GetSection("Jwt"));

            return services;
        }

        public static IServiceCollection AddSettingConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // ---------- Add token config here ----------
            services.Configure<TokenSettings>(configuration.GetSection("TokenSettings"));

            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // ---------- Add Services here ----------
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
