// Copyright (c) 2025 - Jun Dev. All rights reserved

using System.Text.Json.Serialization;

namespace Category.Domain.ValueObjects;

public sealed record CategoryId
{
	public string Value { get; }

	[JsonConstructor]
	public CategoryId(string value) => this.Value = value;

	public static CategoryId Of(string value)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(value);

		if ((value != "root") && (value.Length % 3 > 0))
			throw new ArgumentException("CategoryId wrong format.", value);

		return new CategoryId(value);
	}
}
