USE HFMDB
GO

DROP TABLE DailyTransactions
DROP TABLE StoreInventory
DROP TABLE Stores
DROP TABLE PurchaseLocation
DROP TABLE Inventory

CREATE TABLE PurchaseLocation
(
	LocationId INT IDENTITY(1, 1) PRIMARY KEY,
	LocationName Varchar(100)
)

CREATE TABLE Inventory(
	InventoryId INT IDENTITY(1, 1) PRIMARY KEY,
	InventoryName VARCHAR(500) NOT NULL,
	InventoryDetails VARCHAR(500) NOT NULL,
)

CREATE TABLE Stores(
	StoreId INT IDENTITY(1, 1) PRIMARY KEY,
	StoreName VARCHAR(500),
	StoreDetails VARCHAR(500),
	LocationId INT REFERENCES PurchaseLocation(LocationId)
)

CREATE TABLE StoreInventory(
	StoreInventoryId INT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	StoreId INT REFERENCES Stores(StoreId) NOT NULL,
	InventoryId INT REFERENCES Inventory(InventoryId),
	LocationId INT REFERENCES PurchaseLocation(LocationId),
	Quantity DECIMAL(10, 2),
	UnitAmount DECIMAL(10, 2),
	TotalAmount DECIMAL(10, 2) NOT NULL,
	MRP DECIMAL(10, 2) NOT NULL,
	Tax DECIMAL(10, 2) NOT NULL,
	ModifiedDate DATETIME NOT NULL,
	CreatedDate DATETIME NOT NULL
)

CREATE TABLE DailyTransactions
(
	DailyTransactionId INT IDENTITY(1, 1) PRIMARY KEY,
	StoreId INT REFERENCES Stores(StoreId),
	PurchaseDate DATETIME NOT NULL
)
