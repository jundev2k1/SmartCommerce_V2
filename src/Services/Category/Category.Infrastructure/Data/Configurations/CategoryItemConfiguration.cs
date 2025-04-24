// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Category.Infrastructure.Data.Configurations;

public sealed class CategoryItemConfiguration : IEntityTypeConfiguration<CategoryItem>
{
	public void Configure(EntityTypeBuilder<CategoryItem> builder)
	{
		builder.ToTable("category");

        builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasConversion(x => x.Value, x => CategoryId.Of(x));
		builder.Property(x => x.ParentId).HasConversion(x => x.Value, x => CategoryId.Of(x));
		builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
		builder.Property(x => x.Avatar).IsRequired().HasMaxLength(200);
		builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
		builder.Property(x => x.Priority).IsRequired();
		builder.Property(x => x.ValidFlg).IsRequired();
		builder.Property(x => x.DelFlg).IsRequired();
	}
}
