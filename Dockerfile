FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

COPY PokEmuBasic.slnx .
COPY PokEmuBasic.API/PokEmuBasic.API.csproj PokEmuBasic.API/
COPY PokEmuBasic.Application/PokEmuBasic.Application.csproj PokEmuBasic.Application/
COPY PokEmuBasic.Domain/PokEmuBasic.Domain.csproj PokEmuBasic.Domain/
COPY PokEmuBasic.Infrastructure/PokEmuBasic.Infrastructure.csproj PokEmuBasic.Infrastructure/

RUN dotnet restore PokEmuBasic.slnx

COPY . .
WORKDIR "/src/PokEmuBasic.API"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://*:5294
EXPOSE 5294


ENTRYPOINT ["dotnet", "PokEmuBasic.API.dll"]