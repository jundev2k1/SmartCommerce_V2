// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Clients;
using BuildingBlocks.Contracts.Grpc.Interface;
using BuildingBlocks.Contracts.Grpc.Product;
using BuildingBlocks.Contracts.Grpc.User;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Contracts.Grpc.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddGrpcClients(this IServiceCollection services)
    {
        // Add gRPC client for Product service
        services.AddGrpcClient<ProductProtoService.ProductProtoServiceClient>(options =>
        {
            options.Address = new Uri("http://product.api:8080");
        });
        services.AddScoped<IProductClient, ProductClient>();

        // Add gRPC client for User service
        services.AddGrpcClient<UserProtoService.UserProtoServiceClient>(options =>
        {
            options.Address = new Uri("http://user.api:8080");
        });
        services.AddScoped<IUserClient, UserClient>();

        services.AddScoped<IGrpcClientFacade, GrpcClientFacade>();
        return services;
    }
}
