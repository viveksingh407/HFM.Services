CREATE TABLE BankAccountType
(
	BankAccountTypeId INT IDENTITY(1, 1) PRIMARY KEY,
	BankAccountTypeName VARCHAR(50) NOT NULL,
)

INSERT INTO BankAccountType(BankAccountTypeName) VALUES ('Chase')
INSERT INTO BankAccountType(BankAccountTypeName) VALUES ('BOFA-Checkings Account')
INSERT INTO BankAccountType(BankAccountTypeName) VALUES ('BOFA-Credit Card Account')
INSERT INTO BankAccountType(BankAccountTypeName) VALUES ('ICICI - NRE')
INSERT INTO BankAccountType(BankAccountTypeName) VALUES ('ICICI - NRO')

CREATE TABLE BankStatements
(
	BankStatementId INT IDENTITY(1, 1) PRIMARY KEY,
	BankAccountTypeId INT REFERENCES BankAccountType(BankAccountTypeId) NOT NULL,
	TransactionDate DATETIME NOT NULL,
	PaymentDate DATETIME,
	PostingDate DATETIME NOT NULL,
	TransactionDescription VARCHAR(100) NOT NULL,
	TransacionNumber INT,
	Amount DECIMAL(10, 2) NOT NULL,
	BalanceAmount DECIMAL(10, 2),
)