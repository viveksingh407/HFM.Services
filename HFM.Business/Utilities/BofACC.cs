using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Utilities
{
    public class BofACC
    {
        public class Statement
        {
            public DateTime PurchaseDate { get; set; }
            public DateTime PostingDate { get; set; }
            public string Description { get; set; }
            public int TransactionNumber { get; set; }
            public int AccountType { get; set; }
            public decimal TransactionAmount { get; set; }
            public decimal BalanceAmount { get; set; }
        }

        public static void BofAStatements()
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
                year = Path.GetFileName(statementPath).Substring(0, 4);
                statementText = File.ReadAllLines(statementPath).Where(n => !string.IsNullOrEmpty(n)).Select(n => n.Trim()).ToList();

                if (statementText.Contains("continuedonnextpage...") && statementText.Contains("Transactionscontinued"))
                {
                    var tempStartIndex = statementText.IndexOf("continuedonnextpage...");
                    var tempEndIndex = statementText.FindIndex(tempStartIndex, n => n.StartsWith("Transactionscontinued"));

                    statementText.RemoveRange(tempStartIndex, (tempEndIndex - tempStartIndex));
                }

                startIndex = statementText.IndexOf("Purchases and Adjustments");
                endIndex = statementText.FindIndex(n => n.StartsWith("Total fees charged in"));

                statements = statementText.GetRange(startIndex, endIndex - startIndex).Where(n => n.StartsWith("0") || n.StartsWith("1")).ToList();

                foreach (var transaction in statements)
                {
                    transactions.Add(GetStatement("2016", transaction));
                }
            }

            AddStatements(transactions.Where(n => n.AccountType != 0).OrderBy(n => n.PurchaseDate).ToList());
        }

        private static Statement GetStatement(string year, string statement)
        {
            string[] data = new string[4];
            var statementData = new Statement();

            var purchaseDate = Convert.ToDateTime(string.Concat("2016", "/", statement.Substring(0, 5)));
            var postingDate = Convert.ToDateTime(string.Concat("2016", "/", statement.Substring(6, 5)));
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
    }
}
