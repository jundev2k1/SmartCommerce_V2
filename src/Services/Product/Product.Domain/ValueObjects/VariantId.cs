// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Product.Domain.ValueObjects;

public record VariantId
{
	public string Value { get; }
	private VariantId(string value) => this.Value = value;
	public static VariantId Of(string variantId)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(variantId);

		return new VariantId(variantId);
	}
}
