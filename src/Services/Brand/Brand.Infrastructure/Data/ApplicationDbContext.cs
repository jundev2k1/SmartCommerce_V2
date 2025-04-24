// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Reflection;
using Brand.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Brand.Infrastructure.Data;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }

	public DbSet<BrandItem> Brands => Set<BrandItem>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);
	}
}
