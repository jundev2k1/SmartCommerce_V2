// Copyright (c) 2025 - Jun Dev. All rights reserveds

using Category.Application.Categories.Mapping;

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
		ConfigureMapster();

		return app;
	}

	private static void ConfigureMapster()
	{
		TypeAdapterConfig.GlobalSettings.Scan(typeof(CategoryMapping).Assembly);
	}
}
