USE [HomeFinanceDB]
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


INSERT INTO [dbo].QuantityTypes(QuantityTypeName) VALUES('1 Packet')

INSERT INTO [dbo].ItemCategories(ItemCategoryName) VALUES('Food')
INSERT INTO [dbo].ItemCategories(ItemCategoryName) VALUES('Home')
INSERT INTO [dbo].ItemCategories(ItemCategoryName) VALUES('Household')

INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Appetizers')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Baking')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Batter')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Beverage Powder')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Beverages')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Car')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Cleaning Products')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Dairy')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Dal')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Flour')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Frozen')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Miscelleneous')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Noodles')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Nuts\Dry Fruits')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Oil')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Pooja Items')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Ready to eat')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Rice')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Salt')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Spices')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Sugar')
INSERT INTO [dbo].ItemSubCategories(ItemSubCategoryName) VALUES('Toiletries')


INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Papad', 1, 1, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Baking Soda', 1, 2, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Baking powder', 1, 2, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Idli Batter', 1, 3, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dosa Batter', 1, 3, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tea Powder', 1, 4, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Coffee Powder', 1, 4, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tea', 1, 5, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Coffee', 1, 5, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Coke)', 1, 5, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Ginger Ale)', 1, 5, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Root Beer)', 1, 5, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Pepsi)', 3, 5, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Gas', 3, 6, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Car wash', 3, 6, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Maintainence', 3, 6, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Car Insurance', 3, 6, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dish washing liquids', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dish washing packs', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Washing powder', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Washing soaps', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Toilet cleaner', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Floor cleaner', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Kitchen cleaner', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sanitary pads', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Toilet paper', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Kitchen tissue', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Garbage bags', 3, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Car cleaner/Car refreshner', 1, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dettol', 1, 7, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ghee or butter', 1, 8, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Butter', 1, 8, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Milk', 1, 8, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cheese (Mozzarella)', 1, 8, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cheese (Cheddar)', 1, 8, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Paneer', 1, 8, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Rajma', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Toor dal', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('DhuliMoong', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dhuli Urad', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sabut Urad', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Saabut moong', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Chana dal', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Split urad dal', 1, 9, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Wheat flour', 1, 10, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Maida', 1, 10, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Rice flour', 1, 10, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Besan flour', 1, 10, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Frozen Fruits', 1, 11, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Frozen Vegetables', 1, 11, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Light bulbs', 1, 12, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Batteries', 1, 12, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Candles', 1, 12, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Maggie', 3, 13, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Noodles', 3, 13, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pasta', 3, 13, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sphagetti', 3, 13, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Peanuts', 3, 14, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cooking Oil', 3, 15, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Mustard Oil', 1, 15, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Olive Oil', 1, 15, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Match box', 1, 16, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Deepa oil', 1, 16, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cotton thread', 1, 16, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Camphor', 1, 16, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Incense sticks', 1, 16, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dhoop', 1, 16, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Rock candy or dry grapes for naivedyam', 1, 16, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tikki', 1, 17, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Samosa', 1, 17, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pastry Sheets', 1, 17, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Basmati rice', 1, 18, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Poha (Thick)', 1, 18, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Poha (Thin)', 1, 18, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Salt', 1, 19, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Turmeric Powder', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Red chilli powder', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dhania powder', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Garam masala powder', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Chat masala powder', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pav Bhaji Masala', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Biryani Masala', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Garlic paste', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ginger Paste', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ginger Garlic Paste', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Mustard seeds', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pepper', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cumin seeds/jeera', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Coriander seeds/Dhania', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Fennel seeds', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dry ginger piece or powder', 1, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Black or white sesame seeds', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ajwain', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Hing/Asafetida', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cardamom/Elakki', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cashew nuts', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Badam or other nuts', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cinnamon', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cloves', 3, 20, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Jaggery', 3, 21, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sugar', 3, 21, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tooth paste', 3, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tooth brush', 3, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Bathing soap', 3, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Shampoo/Hair conditioner', 3, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Face powder', 1, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Hand sanitizer', 1, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Deodarant', 1, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Body lotion', 1, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Kajal/Kum kum/stickers', 1, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Shaving lotion', 1, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Shaving cream', 2, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Hair gel', 2, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Razer blades', 2, 22, 1, 1)
INSERT INTO [dbo].Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Baby products', 2, 22, 1, 1)

GO


