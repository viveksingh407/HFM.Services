USE [HomeFinanceDB]
GO

Select *
FROM dbo.Items i WITH(NOLOCK)
INNER JOIN dbo.ItemCategories ic WITH(NOLOCK) ON i.ItemCategoryId = ic.ItemCategoryId
INNER JOIN dbo.ItemSubCategories isc WITH(NOLOCK) ON i.ItemSubCategoryId = isc.ItemSubCategoryId
INNER JOIN dbo.Stores s WITH(NOLOCK) ON i.StoreId = s.StoreId
INNER JOIN dbo.StoreInventory si WITH(NOLOCK) ON si.StoreId = s.StoreId
INNER JOIN dbo.Inventory inv WITH(NOLOCK) ON inv.InventoryId = si.InventoryId
INNER JOIN dbo.PurchaseLocation pl WITH(NOLOCK) ON pl.LocationId = s.LocationId
INNER JOIN dbo.QuantityTypes q WITH(NOLOCK) ON i.QuantityId = q.QuantityTypeId