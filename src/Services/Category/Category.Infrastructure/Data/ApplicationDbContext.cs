// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Reflection;
using Category.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Category.Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	public DbSet<CategoryItem> Categories => Set<CategoryItem>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}
