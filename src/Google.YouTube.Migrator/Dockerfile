#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Google.YouTube.Migrator/Google.YouTube.Migrator.csproj", "src/Google.YouTube.Migrator/"]
COPY ["src/Google.YouTube.EntityFrameworkCore/Google.YouTube.EntityFrameworkCore.csproj", "src/Google.YouTube.EntityFrameworkCore/"]
COPY ["src/Google.YouTube.Core/Google.YouTube.Core.csproj", "src/Google.YouTube.Core/"]
COPY ["src/Google.YouTube.Core.Shared/Google.YouTube.Core.Shared.csproj", "src/Google.YouTube.Core.Shared/"]
RUN dotnet restore "src/Google.YouTube.Migrator/Google.YouTube.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Google.YouTube.Migrator"
RUN dotnet build "Google.YouTube.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Google.YouTube.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Google.YouTube.Migrator.dll", "-s"]
