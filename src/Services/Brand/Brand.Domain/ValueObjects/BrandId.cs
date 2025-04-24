// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Brand.Domain.ValueObjects;

public sealed record BrandId
{
	public string Value { get; }
	private BrandId(string value) => this.Value = value;

	public static BrandId Of(string value)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(value);

		return new BrandId(value);
	}
}
