﻿// Copyright (c) 2025 - Jun Dev. All rights reserveds

namespace Brand.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services)
	{
		services.AddCarter();

		return services;
	}
	public static IApplicationBuilder UseApiServices(this WebApplication app)
	{
		app.MapCarter();

		return app;
	}
}
