using PokEmuBasic.Infrastructure.IOC;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddInfrastructure(builder.Configuration)
        .AddCorsConfig()
        .AddEndpointsApiExplorer()
        .AddSwaggerGen()
        .AddControllers();

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
