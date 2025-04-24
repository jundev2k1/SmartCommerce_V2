// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Brand.Infrastructure.Data.Extensions;

internal class InitialData
{
	public static IEnumerable<BrandItem> Brands =>
		new List<BrandItem>()
		{
			BrandItem.Create(BrandId.Of("brand001"), "Adidas", string.Empty, string.Empty, string.Empty, "system", "system"),
			BrandItem.Create(BrandId.Of("brand002"), "Balenciaga", string.Empty, string.Empty, string.Empty, "system", "system"),
			BrandItem.Create(BrandId.Of("brand003"), "Converse", string.Empty, string.Empty, string.Empty, "system", "system"),
			BrandItem.Create(BrandId.Of("brand004"), "Fila", string.Empty, string.Empty, string.Empty, "system", "system"),
			BrandItem.Create(BrandId.Of("brand005"), "Nike", string.Empty, string.Empty, string.Empty, "system", "system"),
		};
}
