// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Category.Application.Categories.Dtos;

public sealed class CategoryDto
{
	public string ParentId { get; set; } = string.Empty;
	public string Id { get; set; } = string.Empty;
	public string Name { get; set; } = string.Empty;
	public string Avatar { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int Priority { get; set; } = 0;
	public bool ValidFlg { get; set; } = true;
	public bool DelFlg { get; set; } = true;
	public DateTime? CreatedAt { get; set; }
	public string? CreatedBy { get; set; }
	public DateTime? LastModified { get; set; }
	public string? LastModifiedBy { get; set; }
}
