// Copyright (c) 2025 - Jun Dev. All rights reserved

using Category.Domain.Abstractions;

namespace Category.Domain.Models;

public sealed class CategoryItem : Entity<CategoryId>
{
	public CategoryId ParentId { get; private set; } = default!;
	public string Name { get; private set; } = string.Empty;
	public string Avatar { get; private set; } = string.Empty;
	public string Description { get; private set; } = string.Empty;
	public int Priority { get; private set; } = 0;
	public bool ValidFlg { get; private set; } = true;
	public bool DelFlg { get; private set; } = true;

	public static CategoryItem Create(
		CategoryId categoryId,
		CategoryId parentId,
		string name,
		string avatar,
		string desc,
		int priority,
		string createdBy,
		string lastModifiedBy,
		DateTime? createdAt = null,
		DateTime? lastModified = null,
		bool validFlg = true,
		bool delFlg = false)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(name);

		var category = new CategoryItem
		{
			Id = categoryId,
			ParentId = parentId,
			Name = name,
			Avatar = avatar,
			Description = desc,
			Priority = priority,
			ValidFlg = validFlg,
			DelFlg = delFlg,
			CreatedAt = createdAt ?? DateTime.UtcNow,
			CreatedBy = createdBy,
			LastModified = lastModified ?? DateTime.UtcNow,
			LastModifiedBy = lastModifiedBy
		};

		return category;
	}
}
