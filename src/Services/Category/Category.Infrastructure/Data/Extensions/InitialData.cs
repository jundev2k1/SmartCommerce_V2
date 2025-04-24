// Copyright (c) 2025 - Jun Dev. All rights reserved

namespace Category.Infrastructure.Data.Extensions;

internal class InitialData
{
	public static IEnumerable<CategoryItem> Categories =>
		new List<CategoryItem>()
		{
			CategoryItem.Create(CategoryId.Of("001"), CategoryId.Of("root"), "Fastion", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("001001"), CategoryId.Of("001"), "Summer", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("001001001"), CategoryId.Of("001001"), "Bikini", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("001002"), CategoryId.Of("001"), "Winter", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("001002001"), CategoryId.Of("001"), "Cold Coats", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("002"), CategoryId.Of("root"), "Electrical", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("002001"), CategoryId.Of("root"), "Office", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("002001001"), CategoryId.Of("002"), "PC", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("002001002"), CategoryId.Of("002"), "Gears", "", "", 0, "system", "system"),
			CategoryItem.Create(CategoryId.Of("002001003"), CategoryId.Of("002"), "Accessories", "", "", 0, "system", "system"),
		};
}
