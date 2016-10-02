using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Utilities
{
    public class bofaCC
    {
        public static IList<Statement> BofAStatements(bool addToDB)
        {
            var statementText = new List<string>();
            var data = new Statement();
            var transactions = new List<Statement>() as IList<Statement>;
            var allTransactions = new List<Statement>() as IList<Statement>;
            var statements = new List<string>() as IList<string>;
            var allStatements = new List<string>() as IList<string>;
            var path = @"M:\Data\Bank Statements\BofA\Credit Card 2016\Text";

            var startIndex = -1;
            var endIndex = -1;

            var statementPaths = Directory.GetFiles(path, "*.txt");

            var year = string.Empty;

            foreach (var statementPath in statementPaths)
            {
                year = Regex.Split(Path.GetFileName(statementPath), @"[^0-9\.]+").Where(n => n.StartsWith("201")).FirstOrDefault();
                statementText = File.ReadAllLines(statementPath).Where(n => !string.IsNullOrEmpty(n)).Select(n => n.Trim()).ToList();
                var isMultiMonthStatement = statementText[2].StartsWith("December");

                if (statementText.Contains("continuedonnextpage...") && statementText.Contains("Transactionscontinued"))
                {
                    var tempStartIndex = statementText.IndexOf("continuedonnextpage...");
                    var tempEndIndex = statementText.FindIndex(tempStartIndex, n => n.StartsWith("Transactionscontinued"));

                    statementText.RemoveRange(tempStartIndex, (tempEndIndex - tempStartIndex));
                }

                startIndex = statementText.IndexOf("Purchases and Adjustments");
                endIndex = statementText.FindIndex(n => n.StartsWith("Total fees charged in"));

                statements = statementText.GetRange(startIndex, endIndex - startIndex).Where(n => n.StartsWith("0") || n.StartsWith("1")).ToList();

                decimal balanceAmount = 0;
                foreach (var transaction in statements)
                {
                    var currentStatement = GetStatement(transaction, isMultiMonthStatement, year);
                    currentStatement.BalanceAmount = balanceAmount + currentStatement.TransactionAmount;
                    transactions.Add(currentStatement);
                    balanceAmount = currentStatement.BalanceAmount;
                }
            }

            return transactions;
        }

        private static Statement GetStatement(string statement, bool isMultiMonthStatement, string year)
        {
            string[] data = new string[4];
            var statementData = new Statement();

            year = (isMultiMonthStatement && statement.Substring(0, 2) == "12") ? Convert.ToString(Convert.ToInt32(year) - 1) : year;

            var purchaseDate = GetDate(statement.Substring(0, 5), year);
            var postingDate = GetDate(statement.Substring(6, 5), year);

            var remainingStatement = statement.Substring(12);

            //get amount as the regex will extract all th decimals from the string.
            var temp = Regex.Split(remainingStatement, @"[^0-9\.]+");

            if (!(temp.Distinct().Count() == 1 && string.IsNullOrEmpty(temp.Distinct().First())))
            {
                var transactionNumber = Convert.ToInt32(temp[temp.Length - 2]);
                var amount = Convert.ToDecimal(temp[temp.Length - 1]);

                amount = remainingStatement.Contains(amount + "CR") ? amount * -1 : amount;

                var description = remainingStatement.Substring(0, remainingStatement.IndexOf(temp[temp.Length - 2])).Trim();

                statementData = new Statement()
                {
                    PurchaseDate = purchaseDate,
                    Description = description,
                    TransactionAmount = amount,
                    BalanceAmount = 0,
                    PostingDate = postingDate,
                    TransactionDate = purchaseDate,
                    AccountType = 3,
                    TransactionNumber = transactionNumber
                };
            }

            return statementData;
        }

        private static bool AddStatements(IList<Statement> statements)
        {
            bool isSuccess = false;

            BankStatementsRepository repo = new BankStatementsRepository();

            try
            {
                var a = statements.Where(n => n.AccountType == 0);
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
            }
            catch (Exception ex)
            {
                throw ex;
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

