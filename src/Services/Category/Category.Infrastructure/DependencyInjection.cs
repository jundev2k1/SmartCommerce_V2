// Copyright (c) 2025 - Jun Dev. All rights reserved

using BuildingBlocks.Caches;
using BuildingBlocks.Caching;
using Category.Application.Data;
using Category.Infrastructure.Data;
using Category.Infrastructure.Data.Caching;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Category.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("Database");
		services.AddDbContext<ApplicationDbContext>(option =>
		{
			option.UseNpgsql(connectionString)
				.UseSnakeCaseNamingConvention();
		});
		services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

		services.AddRedisCaching(configuration);

		return services;
	}

	private static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration configuration)
    {
		services.AddStackExchangeRedisCache(option =>
		{
			option.Configuration = configuration.GetConnectionString("Redis");
			option.InstanceName = "Category";
        });

        services.AddSingleton<IRedisCacheService, RedisCacheService>();
        services.AddScoped<ICategoryCacheService, CategoryCacheService>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this WebApplication app)
	{
		return app;
	}
}
