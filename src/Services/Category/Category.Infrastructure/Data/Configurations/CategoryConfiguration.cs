// Copyright (c) 2025 - Jun Dev. All rights reserved

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Category.Infrastructure.Data.Configurations;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<CategoryItem>
{
	public void Configure(EntityTypeBuilder<CategoryItem> builder)
	{
		builder.ToTable("category");

        builder.HasKey(x => x.Id);
		builder.Property(x => x.Id).HasConversion(x => x.Value, x => CategoryId.Of(x));
		builder.Property(x => x.ParentId).HasConversion(x => x.Value, x => CategoryId.Of(x));
		builder.Property(x => x.Name).IsRequired().HasMaxLength(100).HasDefaultValue(string.Empty);
		builder.Property(x => x.Avatar).IsRequired().HasMaxLength(200).HasDefaultValue(string.Empty);
		builder.Property(x => x.Description).IsRequired().HasMaxLength(500).HasDefaultValue(string.Empty);
		builder.Property(x => x.Priority).IsRequired().HasDefaultValue(0);
		builder.Property(x => x.ValidFlg).IsRequired().HasDefaultValue(true);
		builder.Property(x => x.DelFlg).IsRequired().HasDefaultValue(false);
		builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValueSql("NOW()");
		builder.Property(x => x.CreatedBy).IsRequired().HasDefaultValue(string.Empty);
		builder.Property(x => x.LastModified).IsRequired().HasDefaultValueSql("NOW()");
        builder.Property(x => x.LastModifiedBy).IsRequired().HasDefaultValue(string.Empty);
	}
}
