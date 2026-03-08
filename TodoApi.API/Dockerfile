# ── Stage 1: Build ────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY TodoApi.Domain/TodoApi.Domain.csproj TodoApi.Domain/
COPY TodoApi.Application/TodoApi.Application.csproj TodoApi.Application/
COPY TodoApi.Infrastructure/TodoApi.Infrastructure.csproj TodoApi.Infrastructure/
COPY TodoApi.API/TodoApi.API.csproj TodoApi.API/

# Restore dependencies
RUN dotnet restore TodoApi.API/TodoApi.API.csproj

# Copy all source code
COPY . .

# Build and publish
RUN dotnet publish TodoApi.API/TodoApi.API.csproj -c Release -o /app/publish

# ── Stage 2: Runtime ──────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "TodoApi.API.dll"]