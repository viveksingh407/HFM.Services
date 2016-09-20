USE HFMDB
GO

CREATE TABLE QuantityTypes (
	QuantityTypeId INT IDENTITY(1, 1) PRIMARY KEY,
	QuantityTypeName VARCHAR(25)
)

CREATE TABLE ItemCategories (
	ItemCategoryId INT IDENTITY(1, 1) PRIMARY KEY,
	ItemCategoryName VARCHAR(50)
)

CREATE TABLE ItemSubCategories (
	ItemSubCategoryId INT IDENTITY(1, 1) PRIMARY KEY,
	ItemSubCategoryName VARCHAR(50),
	ItemCategoryId INT REFERENCES ItemCategories(ItemCategoryId)
)

CREATE TABLE Items (
	ItemId INT IDENTITY(1, 1) PRIMARY KEY,
	ItemName VARCHAR(50),
	ItemCategoryId INT REFERENCES ItemCategories(ItemCategoryId),
	ItemSubCategoryId INT REFERENCES ItemSubCategories(ItemSubCategoryId),
	StoreId INT REFERENCES Stores(StoreId),
	QuantityId INT REFERENCES QuantityTypes(QuantityTypeId),
)

CREATE TABLE DailyPurchase
(
	DailyPurchaseId INT IDENTITY(1, 1) PRIMARY KEY,
	PurchasedItemId INT REFERENCES Items(ItemId) NOT NULL,
	Price DECIMAL(5, 2) NOT NULL,
	Quantity DECIMAL(5, 2) NOT NULL,
	PurchaseDate DATETIME,
	ModifiedDate DATETIME,
	CreatedDate DATETIME,
)

