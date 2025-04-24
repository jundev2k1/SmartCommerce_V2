# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Category/Category.API/Category.API.csproj", "Services/Category/Category.API/"]
COPY ["Services/Category/Category.Application/Category.Application.csproj", "Services/Category/Category.Application/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
COPY ["Services/Category/Category.Domain/Category.Domain.csproj", "Services/Category/Category.Domain/"]
COPY ["Services/Category/Category.Infrastructure/Category.Infrastructure.csproj", "Services/Category/Category.Infrastructure/"]
RUN dotnet restore "./Services/Category/Category.API/Category.API.csproj"
COPY . .
WORKDIR "/src/Services/Category/Category.API"
RUN dotnet build "./Category.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Category.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Category.API.dll"]