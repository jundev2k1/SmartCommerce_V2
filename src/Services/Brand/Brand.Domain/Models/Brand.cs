// Copyright (c) 2025 - Jun Dev. All rights reserved

using Brand.Domain.Abstractions;

namespace Brand.Domain.Models;

public sealed class BrandItem : Entity<BrandId>
{
	public string Name { get; private set; } = string.Empty;
	public string LogoUrl { get; private set; } = string.Empty;
	public string Slug { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
	public bool ValidFlg { get; private set; } = true;
	public bool DelFlg { get; private set; } = true;

	public static BrandItem Create(
		BrandId brandId,
		string name,
		string logoUrl,
		string slug,
		string desc,
		string createdBy,
		string lastModifiedBy,
		DateTime? createdAt = null,
		DateTime? lastModified = null,
		bool validFlg = true,
		bool delFlg = false)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(name);

		var brand = new BrandItem
		{
			Id = brandId,
			Name = name,
			LogoUrl = logoUrl,
			Slug = slug,
            Description = desc,
			ValidFlg = validFlg,
			DelFlg = delFlg,
			CreatedAt = createdAt ?? DateTime.UtcNow,
			CreatedBy = createdBy,
			LastModified = lastModified ?? DateTime.UtcNow,
			LastModifiedBy = lastModifiedBy
		};

		return brand;
	}
}
