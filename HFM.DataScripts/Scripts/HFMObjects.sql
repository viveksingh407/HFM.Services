USE [master]
GO
/****** Object:  Database [HomeFinanceDB]    Script Date: 12/24/2016 10:54:35 AM ******/
CREATE DATABASE [HomeFinanceDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HomeFinanceDB', FILENAME = N'M:\Data\HFM\ItemData\DB\HomeFinanceDB.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HomeFinanceDB_log', FILENAME = N'M:\Data\HFM\ItemData\DB\HomeFinanceDB_log.ldf' , SIZE = 2304KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HomeFinanceDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HomeFinanceDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HomeFinanceDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HomeFinanceDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HomeFinanceDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HomeFinanceDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HomeFinanceDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HomeFinanceDB] SET  MULTI_USER 
GO
ALTER DATABASE [HomeFinanceDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HomeFinanceDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HomeFinanceDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HomeFinanceDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [HomeFinanceDB]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 12/24/2016 10:54:35 AM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[DailyPurchase]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyPurchase](
	[DailyPurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[PurchasedItemId] [int] NOT NULL,
	[Price] [decimal](5, 2) NOT NULL,
	[Quantity] [decimal](5, 2) NOT NULL,
	[PurchaseDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[DailyPurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DailyTransactions]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailyTransactions](
	[DailyTransactionId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NULL,
	[PurchaseDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DailyTransactionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inventory]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inventory](
	[InventoryId] [int] IDENTITY(1,1) NOT NULL,
	[InventoryName] [varchar](500) NOT NULL,
	[InventoryDetails] [varchar](500) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemCategories]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemCategories](
	[ItemCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ItemCategoryName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](50) NULL,
	[ItemCategoryId] [int] NULL,
	[ItemSubCategoryId] [int] NULL,
	[StoreId] [int] NULL,
	[QuantityId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemSubCategories]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemSubCategories](
	[ItemSubCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ItemSubCategoryName] [varchar](50) NULL,
	[ItemCategoryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ItemSubCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseLocation]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseLocation](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuantityTypes]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuantityTypes](
	[QuantityTypeId] [int] IDENTITY(1,1) NOT NULL,
	[QuantityTypeName] [varchar](25) NULL,
PRIMARY KEY CLUSTERED 
(
	[QuantityTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StoreInventory]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreInventory](
	[StoreInventoryId] [int] IDENTITY(1,1) NOT NULL,
	[StoreId] [int] NOT NULL,
	[InventoryId] [int] NULL,
	[LocationId] [int] NULL,
	[Quantity] [decimal](10, 2) NULL,
	[UnitAmount] [decimal](10, 2) NULL,
	[TotalAmount] [decimal](10, 2) NOT NULL,
	[MRP] [decimal](10, 2) NOT NULL,
	[Tax] [decimal](10, 2) NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StoreInventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Stores]    Script Date: 12/24/2016 10:54:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stores](
	[StoreId] [int] IDENTITY(1,1) NOT NULL,
	[StoreName] [varchar](500) NULL,
	[StoreDetails] [varchar](500) NULL,
	[LocationId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StoreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[DailyPurchase]  WITH CHECK ADD FOREIGN KEY([PurchasedItemId])
REFERENCES [dbo].[Items] ([ItemId])
GO
ALTER TABLE [dbo].[DailyTransactions]  WITH CHECK ADD FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[ItemCategories] ([ItemCategoryId])
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([ItemSubCategoryId])
REFERENCES [dbo].[ItemSubCategories] ([ItemSubCategoryId])
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([QuantityId])
REFERENCES [dbo].[QuantityTypes] ([QuantityTypeId])
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[ItemSubCategories]  WITH CHECK ADD FOREIGN KEY([ItemCategoryId])
REFERENCES [dbo].[ItemCategories] ([ItemCategoryId])
GO
ALTER TABLE [dbo].[StoreInventory]  WITH CHECK ADD FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventory] ([InventoryId])
GO
ALTER TABLE [dbo].[StoreInventory]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[PurchaseLocation] ([LocationId])
GO
ALTER TABLE [dbo].[StoreInventory]  WITH CHECK ADD FOREIGN KEY([StoreId])
REFERENCES [dbo].[Stores] ([StoreId])
GO
ALTER TABLE [dbo].[Stores]  WITH CHECK ADD FOREIGN KEY([LocationId])
REFERENCES [dbo].[PurchaseLocation] ([LocationId])
GO
USE [master]
GO
ALTER DATABASE [HomeFinanceDB] SET  READ_WRITE 
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


INSERT INTO QuantityTypes(QuantityTypeName) VALUES('1 Packet')

INSERT INTO ItemCategories(ItemCategoryName) VALUES('Food')
INSERT INTO ItemCategories(ItemCategoryName) VALUES('Home')
INSERT INTO ItemCategories(ItemCategoryName) VALUES('Household')

INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Appetizers')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Baking')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Batter')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Beverage Powder')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Beverages')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Car')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Cleaning Products')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Dairy')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Dal')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Flour')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Frozen')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Miscelleneous')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Noodles')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Nuts\Dry Fruits')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Oil')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Pooja Items')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Ready to eat')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Rice')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Salt')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Spices')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Sugar')
INSERT INTO ItemSubCategories(ItemSubCategoryName) VALUES('Toiletries')


INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Papad', 1, 1, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Baking Soda', 1, 2, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Baking powder', 1, 2, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Idli Batter', 1, 3, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dosa Batter', 1, 3, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tea Powder', 1, 4, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Coffee Powder', 1, 4, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tea', 1, 5, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Coffee', 1, 5, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Coke)', 1, 5, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Ginger Ale)', 1, 5, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Root Beer)', 1, 5, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cold Drink (Pepsi)', 3, 5, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Gas', 3, 6, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Car wash', 3, 6, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Maintainence', 3, 6, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Car Insurance', 3, 6, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dish washing liquids', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dish washing packs', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Washing powder', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Washing soaps', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Toilet cleaner', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Floor cleaner', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Kitchen cleaner', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sanitary pads', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Toilet paper', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Kitchen tissue', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Garbage bags', 3, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Car cleaner/Car refreshner', 1, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dettol', 1, 7, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ghee or butter', 1, 8, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Butter', 1, 8, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Milk', 1, 8, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cheese (Mozzarella)', 1, 8, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cheese (Cheddar)', 1, 8, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Paneer', 1, 8, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Rajma', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Toor dal', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('DhuliMoong', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dhuli Urad', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sabut Urad', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Saabut moong', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Chana dal', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Split urad dal', 1, 9, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Wheat flour', 1, 10, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Maida', 1, 10, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Rice flour', 1, 10, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Besan flour', 1, 10, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Frozen Fruits', 1, 11, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Frozen Vegetables', 1, 11, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Light bulbs', 1, 12, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Batteries', 1, 12, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Candles', 1, 12, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Maggie', 3, 13, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Noodles', 3, 13, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pasta', 3, 13, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sphagetti', 3, 13, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Peanuts', 3, 14, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cooking Oil', 3, 15, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Mustard Oil', 1, 15, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Olive Oil', 1, 15, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Match box', 1, 16, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Deepa oil', 1, 16, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cotton thread', 1, 16, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Camphor', 1, 16, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Incense sticks', 1, 16, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dhoop', 1, 16, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Rock candy or dry grapes for naivedyam', 1, 16, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tikki', 1, 17, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Samosa', 1, 17, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pastry Sheets', 1, 17, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Basmati rice', 1, 18, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Poha (Thick)', 1, 18, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Poha (Thin)', 1, 18, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Salt', 1, 19, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Turmeric Powder', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Red chilli powder', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dhania powder', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Garam masala powder', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Chat masala powder', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pav Bhaji Masala', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Biryani Masala', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Garlic paste', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ginger Paste', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ginger Garlic Paste', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Mustard seeds', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Pepper', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cumin seeds/jeera', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Coriander seeds/Dhania', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Fennel seeds', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Dry ginger piece or powder', 1, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Black or white sesame seeds', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Ajwain', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Hing/Asafetida', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cardamom/Elakki', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cashew nuts', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Badam or other nuts', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cinnamon', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Cloves', 3, 20, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Jaggery', 3, 21, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Sugar', 3, 21, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tooth paste', 3, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Tooth brush', 3, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Bathing soap', 3, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Shampoo/Hair conditioner', 3, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Face powder', 1, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Hand sanitizer', 1, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Deodarant', 1, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Body lotion', 1, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Kajal/Kum kum/stickers', 1, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Shaving lotion', 1, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Shaving cream', 2, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Hair gel', 2, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Razer blades', 2, 22, 1, 1)
INSERT INTO Items (ItemName,ItemCategoryId, ItemSubCategoryId, StoreId, QuantityId) VALUES ('Baby products', 2, 22, 1, 1)

GO