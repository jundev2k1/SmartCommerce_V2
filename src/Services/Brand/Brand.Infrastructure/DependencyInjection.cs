// Copyright (c) 2025 - Jun Dev. All rights reserved

using Brand.Application.Data;
using Brand.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brand.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		services.AddDbContext<ApplicationDbContext>(option =>
		{
			option.UseNpgsql(connectionString)
				.UseSnakeCaseNamingConvention();
		});
		services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

		return services;
	}

	public static IApplicationBuilder UseInfrastructure(this WebApplication app)
	{
		return app;
	}
}
