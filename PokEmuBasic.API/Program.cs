using PokEmuBasic.API.IOC;
using PokEmuBasic.API.Middlewares;
using PokEmuBasic.Application.IOC;
using PokEmuBasic.Infrastructure.IOC;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddSettingConfig(builder.Configuration)
        .AddAuthenticationConfig(builder.Configuration)
        .AddInfrastructure(builder.Configuration)
        .AddRepositories()
        .AddApplicationServices()
        .AddInfrastructureServices()
        .AddControllerConfig()
        .AddModelStateValidationConfig()
        .AddCorsConfig()
        .AddEndpointConfig()
        .AddMappingConfig()
        .AddSwaggerConfig()
        .AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRegisterMiddleware();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
