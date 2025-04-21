// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Domain.ValueObjects;

public record ProductId
{
    public string Value { get; }
    private ProductId(string value) => this.Value = value;
    public static ProductId Of(string productId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productId);

        return new ProductId(productId);
    }
}