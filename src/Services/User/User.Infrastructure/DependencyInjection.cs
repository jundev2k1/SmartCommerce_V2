// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Contracts.Grpc.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace User.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddGrpc();
		services.AddGrpcClients();
		return services;
	}

	public static IApplicationBuilder UseInfrastructure(this WebApplication app)
	{
		return app;
	}
}
