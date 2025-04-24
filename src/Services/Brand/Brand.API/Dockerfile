# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Brand/Brand.API/Brand.API.csproj", "Services/Brand/Brand.API/"]
COPY ["Services/Brand/Brand.Application/Brand.Application.csproj", "Services/Brand/Brand.Application/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Services/Brand/Brand.Domain/Brand.Domain.csproj", "Services/Brand/Brand.Domain/"]
COPY ["Services/Brand/Brand.Infrastructure/Brand.Infrastructure.csproj", "Services/Brand/Brand.Infrastructure/"]
RUN dotnet restore "./Services/Brand/Brand.API/Brand.API.csproj"
COPY . .
WORKDIR "/src/Services/Brand/Brand.API"
RUN dotnet build "./Brand.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Brand.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brand.API.dll"]