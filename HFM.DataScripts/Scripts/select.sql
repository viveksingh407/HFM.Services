USE HFMDB
GO

SELECT td.TransactionDetailsName, tc.TransactionCategoryName, ExpenseTypeName, ExpenseAmountTypeName, TransactionTypeName
FROM TransactionDetails td WITH(NOLOCK)
INNER JOIN TransactionCategory tc WITH(NOLOCK) ON tc.TransactionCategoryId = td.TransactionCategoryId
INNER JOIN ExpenseAmountType eat WITH(NOLOCK) ON eat.ExpenseAmountTypeId = td.ExpenseAmountTypeId
INNER JOIN ExpenseType et WITH(NOLOCK) ON et.ExpenseTypeId = td.ExpenseTypeId
INNER JOIN TransactionType tt WITH(NOLOCK) ON tt.TransactionTypeId = td.TransactionTypeId
WHERE TransactionCategoryName = 'EMI'