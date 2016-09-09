USE [HFMDB]
GO

SET NOCOUNT ON

INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Seattle')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Renton')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Bellevue')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Redmond')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Tukwila')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Kent')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Kirkland')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Fairwood')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Aligarh')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Chandausi')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Noida')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Delhi')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Online(India)')
INSERT INTO [dbo].[PurchaseLocation] ([LocationName]) VALUES ('Online(US)')

INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Rice', 'India Gate 20lbs')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Rice', 'India Gate 10lbs')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Yogurt', 'Gopi')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Potato', 'DK')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Golden Potato', 'Fred Meyer')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Onion', 'DK')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Onion', 'Fred Meyer')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Ginger', 'DK')
INSERT INTO [dbo].[Inventory] ([InventoryName], [InventoryDetails]) VALUES ('Garlic', 'DK')

INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Fred Meyers', 'Renton', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Walmart', 'Renton', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('DK', 'Renton', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Costco', 'Renton', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Target', 'Kent', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Kohl''s', 'Tukwila', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Indian Supermarket', 'Bellevue', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Amazon(US)', 'US', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Amazon(India)', 'India', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Toys r Us', 'Tukwila', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('Carter', 'Tukwila', 1)
INSERT INTO [dbo].[Stores] ([StoreName],[StoreDetails],[LocationId]) VALUES ('H&M', 'Tukwila', 1)

INSERT INTO [dbo].[StoreInventory] ([StoreId], [InventoryId], [LocationId], [Quantity], [UnitAmount], [TotalAmount], [MRP], [Tax], [ModifiedDate], [CreatedDate]) 
	VALUES(1, 1, 1, 1, 20.00, 20.00, 15.00, 5.00, GETDATE(), GETDATE())
INSERT INTO [dbo].[StoreInventory] ([StoreId], [InventoryId], [LocationId], [Quantity], [UnitAmount], [TotalAmount], [MRP], [Tax], [ModifiedDate], [CreatedDate]) 
	VALUES(1, 1, 1, 1, 30.00, 20.00, 25.00, 5.00, GETDATE(), GETDATE())
INSERT INTO [dbo].[StoreInventory] ([StoreId], [InventoryId], [LocationId], [Quantity], [UnitAmount], [TotalAmount], [MRP], [Tax], [ModifiedDate], [CreatedDate]) 
	VALUES(1, 1, 1, 1, 25.00, 20.00, 20.00, 5.00, GETDATE(), GETDATE())
INSERT INTO [dbo].[StoreInventory] ([StoreId], [InventoryId], [LocationId], [Quantity], [UnitAmount], [TotalAmount], [MRP], [Tax], [ModifiedDate], [CreatedDate]) 
	VALUES(1, 1, 1, 1, 15.00, 20.00, 10.00, 5.00, GETDATE(), GETDATE())
INSERT INTO [dbo].[StoreInventory] ([StoreId], [InventoryId], [LocationId], [Quantity], [UnitAmount], [TotalAmount], [MRP], [Tax], [ModifiedDate], [CreatedDate]) 
	VALUES(1, 1, 1, 1, 50.00, 20.00, 40.00, 10.00, GETDATE(), GETDATE())
INSERT INTO [dbo].[StoreInventory] ([StoreId], [InventoryId], [LocationId], [Quantity], [UnitAmount], [TotalAmount], [MRP], [Tax], [ModifiedDate], [CreatedDate]) 
	VALUES(1, 1, 1, 1, 10.00, 20.00, 5.00, 5.00, GETDATE(), GETDATE())

GO


