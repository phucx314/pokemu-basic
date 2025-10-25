using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PokEmuBasic.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Infrastructure.IOC
{
    public partial class Program { }
    public static partial class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var logger = services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();

            // ---------- Add Infrastructure here ----------
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DatabaseContext>(options => options
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention());

            //services.Configure<TokenSettings>(configuration.GetSection("Jwt"));

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
    }
}
