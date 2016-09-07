USE HFMDB
GO

CREATE TABLE ExpenseType
(
	ExpenseTypeId INT IDENTITY(1, 1) PRIMARY KEY,
	ExpenseTypeName VARCHAR(10) NOT NULL,
	ExpenseTypeCode VARCHAR(2) NOT NULL,
)

CREATE TABLE ExpenseAmountType
(
	ExpenseAmountTypeId INT IDENTITY(1, 1) PRIMARY KEY,
	ExpenseAmountTypeName VARCHAR(10) NOT NULL,
	ExpenseAmountTypeCode VARCHAR(2) NOT NULL,
	ExpenseAmountFixedFrom DateTime NULL,
	ExpenseAmountFixedTo DateTime NULL,
)

CREATE TABLE TransactionType
(
	TransactionTypeId INT IDENTITY(1, 1) PRIMARY KEY,
	TransactionTypeName VARCHAR(10) NOT NULL,
	TransactionTypeCode VARCHAR(2) NOT NULL,
)

CREATE TABLE TransactionCategory
(
	TransactionCategoryId INT IDENTITY(1, 1) PRIMARY KEY,
	TransactionCategoryName VARCHAR(50) NOT NULL
)

CREATE TABLE TransactionDetails
(
	TransactionDetailsId INT IDENTITY(1, 1) PRIMARY KEY,
	TransactionCategoryId INT REFERENCES TransactionCategory(TransactionCategoryId) NOT NULL,
	TransactionDetailsName VARCHAR(100) NOT NULL,
	TransactionTypeId INT REFERENCES TransactionType(TransactionTypeId) NOT NULL,
	ExpenseTypeId INT REFERENCES ExpenseType(ExpenseTypeId) NOT NULL,
	ExpenseAmountTypeId INT REFERENCES ExpenseAmountType(ExpenseAmountTypeId) NOT NULL,
	ModifiedDate DATETIME NOT NULL,
	CreatedDate DATETIME NOT NULL
)


