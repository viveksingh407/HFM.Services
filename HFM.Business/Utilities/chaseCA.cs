using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Utilities
{
    public class chaseCA
    {
        public class Taxes
        {
            public string TotalTaxAmount { get; set; }
            public string PostingDate { get; set; }
            public string Description { get; set; }
            public int TransactionNumber { get; set; }
            public int AccountNumber { get; set; }
            public decimal TransactionAmount { get; set; }
        }

        public class Payments
        {
            public string PaymentDate { get; set; }
            public string PostingDate { get; set; }
            public string Description { get; set; }
            public int TransactionNumber { get; set; }
            public int AccountNumber { get; set; }
            public decimal TransactionAmount { get; set; }
        }

        public static IList<Statement> ChaseStatements(bool addToDB)
        {
            var statementText = new List<string>();
            var data = new Statement();
            var transactions = new List<Statement>() as IList<Statement>;
            var allTransactions = new List<Statement>() as IList<Statement>;
            var statements = new List<string>() as IList<string>;
            var allStatements = new List<string>() as IList<string>;
            var path = @"M:\Data\Bank Statements\Chase\Text";

            var transactionStatementStartIndex = -1;
            var transactionStatementEndIndex = -1;

            var statementPaths = Directory.GetFiles(path, "*.txt");

            var year = string.Empty;
            var transactionIdentifier = 1;

            foreach (var statementPath in statementPaths)
            {
                //year = Path.GetFileName(statementPath).Substring(0, 4);
                year = Regex.Split(Path.GetFileName(statementPath), @"[^0-9\.]+").Where(n => n.StartsWith("201")).FirstOrDefault();
                statementText = File.ReadAllLines(statementPath).Where(n => !string.IsNullOrEmpty(n)).Select(n => n.Trim()).ToList();

                transactionStatementStartIndex = statementText.FindIndex(n => string.Compare(n, "TRANSACTION DETAIL", true) == 0) + 2;

                statementText.RemoveRange(0, transactionStatementStartIndex);

                transactionStatementEndIndex = statementText.FindIndex(n => n.StartsWith("Ending Balance"));

                statements = statementText.GetRange(0, transactionStatementEndIndex);

                foreach (var statement in statements)
                {
                    if ((statement.StartsWith("0") || statement.StartsWith("1")) && statement.Contains("."))
                    {
                        data = GetStatement(year, statement, transactionIdentifier);
                        transactions.Add(data);

                        transactionIdentifier += 1;
                    }
                }
            }

            if (transactions.Sum(n => n.TransactionAmount) != transactions.Last().BalanceAmount)
            {
                throw new InvalidOperationException();
            }

            return transactions;

            //if (addToDB)
            //{
            //    AddStatements(transactions.OrderBy(n => n.PurchaseDate).ToList());
            //}
        }

        private static Statement GetStatement(string year, string statement, int transactionIdentifier)
        {
            string[] data = new string[4];

            var mainStatement = statement;

            //get tranaction date
            var transactionDate = Convert.ToDateTime(string.Concat(year, "/", statement.Substring(0, 5)));

            //get remaining string
            statement = statement.Substring(5, statement.Length - 5).Replace("  ", " ").Trim();

            //get second last index of ".". This is to get th amount field. the amount and balance filed can have " ", ",", "" between them.
            //So we identify index after 2 decimal place and add a delimiter.
            var index = statement.Substring(0, statement.LastIndexOf(".")).LastIndexOf(".") + 3;

            //get balance as text from index to statement length.
            var tempBalanceAmount = statement.Substring(index, ((statement.Length) - index)).Trim();

            //remove "," from remaining string. This is to remove "," from decimal amount.
            statement = statement.Substring(0, index).Replace(",", string.Empty).Trim();

            //get amount as the regex will extract all th decimals from the string.
            var temp = Regex.Split(statement, @"[^0-9\.]+");

            //get the amount with leading sign.
            var tempAmount = statement[statement.IndexOf(temp[temp.Length - 1]) - 1] == '-' ? string.Concat("-", temp[temp.Length - 1]) : temp[temp.Length - 1];

            // remove any spaces in the balance.
            var tempBalance = tempBalanceAmount.Replace(" ", string.Empty).Replace(",", string.Empty).Trim();

            var amount = Convert.ToDecimal(tempAmount.Trim());
            var balance = Convert.ToDecimal(tempBalance.Trim());
            var description = statement.Substring(0, statement.IndexOf(tempAmount)).Trim();

            return new Statement()
            {
                PurchaseDate = transactionDate,
                Description = description,
                TransactionAmount = amount,
                BalanceAmount = balance,
                PostingDate = transactionDate,
                AccountType = 1,
                TransactionNumber = transactionIdentifier
            };
        }

        private static bool AddStatements(IList<Statement> statements)
        {
            bool isSuccess = false;

            BankStatementsRepository repo = new BankStatementsRepository();

            foreach (var data in statements)
            {
                repo.Add(new BankStatementsRepository()
                {
                    BankAccountTypeId = data.AccountType,
                    TransactionDate = data.PurchaseDate,
                    PaymentDate = data.PurchaseDate,
                    PostingDate = data.PostingDate,
                    TransactionDescription = data.Description,
                    TransactionNumber = data.TransactionNumber,
                    Amount = data.TransactionAmount,
                    BalanceAmount = data.BalanceAmount
                });
            }

            return isSuccess;
        }

        private static string GetYear(string dateRange)
        {
            string transactionDate = string.Empty;

            return Regex.Split(dateRange, @"[^0-9\.]+").Where(n => n.StartsWith("201")).FirstOrDefault();
        }

        private static DateTime GetDate(string datePart, string yearPart)
        {
            return Convert.ToDateTime(string.Concat(datePart, "/", yearPart));
        }
    }
}
