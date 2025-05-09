using Category.Domain.ValueObjects;

namespace Category.API.Dtos;

public sealed class CategoryDto
{
    public string ParentId { get; set; } = default!;
    public string Id { get; set; } = default!;
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
