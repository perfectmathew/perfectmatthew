# Krok 1: Budowanie
# Używamy SDK w wersji 9.0
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY *.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Krok 2: Finalny obraz
# Używamy runtime ASP.NET w wersji 9.0
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PerfectMatthew.Api.dll"]