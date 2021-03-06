USE [master]
GO
/****** Object:  Database [HomeFinanceDB]    Script Date: 12/25/2016 12:32:32 AM ******/
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
ALTER DATABASE [HomeFinanceDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HomeFinanceDB]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 12/25/2016 12:32:32 AM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datareader] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Table [dbo].[BankAccountType]    Script Date: 12/25/2016 12:32:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankAccountType](
	[BankAccountTypeId] [int] IDENTITY(1,1) NOT NULL,
	[BankAccountTypeName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BankAccountTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BankStatements]    Script Date: 12/25/2016 12:32:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankStatements](
	[BankStatementId] [int] IDENTITY(1,1) NOT NULL,
	[BankAccountTypeId] [int] NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[PaymentDate] [datetime] NULL,
	[PostingDate] [datetime] NOT NULL,
	[TransactionDescription] [varchar](100) NOT NULL,
	[TransacionNumber] [int] NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[BalanceAmount] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[BankStatementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailyPurchase]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[DailyTransactions]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[Inventory]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[ItemCategories]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[Items]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[ItemSubCategories]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[PurchaseLocation]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[QuantityTypes]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[StoreInventory]    Script Date: 12/25/2016 12:32:32 AM ******/
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
/****** Object:  Table [dbo].[Stores]    Script Date: 12/25/2016 12:32:32 AM ******/
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
ALTER TABLE [dbo].[BankStatements]  WITH CHECK ADD FOREIGN KEY([BankAccountTypeId])
REFERENCES [dbo].[BankAccountType] ([BankAccountTypeId])
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
