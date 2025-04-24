// Copyright (c) 2025 - Jun Dev. All rights reserveds

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Brand.Infrastructure.Data.Extensions;

public static class DatabaseExtensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app, CancellationToken cancellationToken = default)
	{
		using var scope = app.Services.CreateScope();
		var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

		dbContext.Database.MigrateAsync().GetAwaiter().GetResult();

		if (!await dbContext.Brands.AnyAsync())
		{
			await dbContext.Brands.AddRangeAsync(InitialData.Brands);
			await dbContext.SaveChangesAsync();
		}
	}
}
