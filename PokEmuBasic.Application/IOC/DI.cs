using Microsoft.Extensions.DependencyInjection;
using PokEmuBasic.Application.Mapping;
using PokEmuBasic.Application.Services;
using PokEmuBasic.Application.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokEmuBasic.Application.IOC
{
    public static partial class DI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // ---------- Add Services here ----------
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICurrentUserContext, CurrentUserContext>();
            services.AddScoped<IPackService, PackService>();
            services.AddScoped<IExpansionService, ExpansionService>();

            return services;
        }

        public static IServiceCollection AddMappingConfig(this IServiceCollection services)
        {
            // ---------- Add Mapping config here ----------
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new CardProfile());
                cfg.AddProfile(new PackProfile());
                cfg.AddProfile(new PackRarityDropRateProfile());
                cfg.AddProfile(new ExpansionProfile());
            });

            return services;
        }
    }
}
