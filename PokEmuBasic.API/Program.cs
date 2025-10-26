using PokEmuBasic.API.IOC;
using PokEmuBasic.Infrastructure.IOC;
using PokEmuBasic.Application.IOC;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddSettingConfig(builder.Configuration)
        .AddAuthenticationConfig(builder.Configuration)
        .AddInfrastructure(builder.Configuration)
        .AddRepositories()
        .AddApplicationServices()
        .AddInfrastructureServices()
        .AddModelStateValidationConfig()
        .AddControllerConfig()
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
