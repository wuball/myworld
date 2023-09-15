#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Google.YouTube.Web.Mvc/Google.YouTube.Web.Mvc.csproj", "src/Google.YouTube.Web.Mvc/"]
COPY ["src/Google.YouTube.Web.Core/Google.YouTube.Web.Core.csproj", "src/Google.YouTube.Web.Core/"]
COPY ["src/Google.YouTube.Application/Google.YouTube.Application.csproj", "src/Google.YouTube.Application/"]
COPY ["src/Google.YouTube.Application.Shared/Google.YouTube.Application.Shared.csproj", "src/Google.YouTube.Application.Shared/"]
COPY ["src/Google.YouTube.Core.Shared/Google.YouTube.Core.Shared.csproj", "src/Google.YouTube.Core.Shared/"]
COPY ["src/Google.YouTube.Core/Google.YouTube.Core.csproj", "src/Google.YouTube.Core/"]
COPY ["src/Google.YouTube.EntityFrameworkCore/Google.YouTube.EntityFrameworkCore.csproj", "src/Google.YouTube.EntityFrameworkCore/"]
COPY ["src/Google.YouTube.GraphQL/Google.YouTube.GraphQL.csproj", "src/Google.YouTube.GraphQL/"]
RUN dotnet restore "src/Google.YouTube.Web.Mvc/Google.YouTube.Web.Mvc.csproj"
COPY . .
WORKDIR "/src/src/Google.YouTube.Web.Mvc"
RUN dotnet build "Google.YouTube.Web.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Google.YouTube.Web.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Google.YouTube.Web.Mvc.dll"]
