// Copyright (c) 2025 - Jun Dev. All rights reserveds

namespace Category.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services)
	{
		services.AddCarter();

		services.AddControllers()
			.AddNewtonsoftJson();

		return services;
	}
	public static IApplicationBuilder UseApiServices(this WebApplication app)
	{
		app.MapCarter();

		return app;
	}
}
