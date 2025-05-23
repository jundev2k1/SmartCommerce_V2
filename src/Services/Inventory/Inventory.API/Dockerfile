# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Inventory/Inventory.API/Inventory.API.csproj", "Services/Inventory/Inventory.API/"]
COPY ["Services/Inventory/Inventory.Application/Inventory.Application.csproj", "Services/Inventory/Inventory.Application/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Services/Inventory/Inventory.Domain/Inventory.Domain.csproj", "Services/Inventory/Inventory.Domain/"]
COPY ["Services/Inventory/Inventory.Infrastructure/Inventory.Infrastructure.csproj", "Services/Inventory/Inventory.Infrastructure/"]
RUN dotnet restore "./Services/Inventory/Inventory.API/Inventory.API.csproj"
COPY . .
WORKDIR "/src/Services/Inventory/Inventory.API"
RUN dotnet build "./Inventory.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Inventory.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.API.dll"]