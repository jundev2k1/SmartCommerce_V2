// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Domain.Models;

public class Product : Entity<ProductId>
{
    public string ProductId { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string ShortDescription { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    public static Product Create(string productId, string name, string description, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(productId, nameof(productId));
        return new Product
        {
            ProductId = productId,
            Name = name,
            Description = description,
            Price = price
        };
    }
}
