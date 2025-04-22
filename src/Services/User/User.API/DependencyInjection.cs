// Copyright (c) 2025 - Jun Dev. All rights reserveds

namespace User.API;

public static class DependencyInjection
{
	public static IServiceCollection AddApiServices(this IServiceCollection services)
	{
		services.AddControllers();
		services.AddOpenApi()
			.AddEndpointsApiExplorer()
			.AddSwaggerGen();
		return services;
	}
	public static IApplicationBuilder UseApiServices(this WebApplication app)
	{
		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
		}
		app.UseAuthorization()
			.UseSwagger()
			.UseSwaggerUI();
		app.MapControllers();
		return app;
	}
}
