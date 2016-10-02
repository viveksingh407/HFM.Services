using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Utilities
{
    public class bofaYearlySummary
    {
        public static IList<Statement> BofAStatements(bool addToDB)
        {
            var statementText = new List<string>();
            var data = new Statement();
            var transactions = new List<Statement>() as IList<Statement>;
            var allTransactions = new List<Statement>() as IList<Statement>;
            var statements = new List<string>();
            var allStatements = new List<string>() as IList<string>;
            var path = @"M:\Data\Bank Statements\BofA\Credit Card Yearly Statement\Text";

            var startIndex = -1;
            var endIndex = -1;

            var statementPaths = Directory.GetFiles(path, "*.txt");

            var year = string.Empty;
            var transactionNumber = 1;

            var categories = new List<string>() { "Merchandise", "Utilities", "Entertainment", "Travel and transportation", "Services", "All other categories" };

            foreach (var statementPath in statementPaths)
            {
                statementText = File.ReadAllLines(statementPath).Where(n => !string.IsNullOrEmpty(n)).Select(n => n.Trim()).ToList();

                year = Convert.ToString(Path.GetFileName(statementPath).Substring("YearEndSummary_".Length, 4));

                startIndex = statementText.FindIndex(0, n => n.Contains("Please note: Here is a list of all your posted transactions."));
                endIndex = statementText.FindIndex(startIndex, n => n.StartsWith("This credit card program is issued and administered"));

                statements = statementText.GetRange(startIndex, (endIndex - startIndex)).Where(n => !string.IsNullOrEmpty(n)).ToList();

                var filterText = statements.Where(n => n.StartsWith("(")).ToList();

                var filterStartIndex = 0;
                var filterEndIndex = 0;
                string[] statement;

                foreach (var text in filterText)
                {
                    statement = new string[4];
                    filterEndIndex = statements.FindIndex(filterStartIndex, n => string.Compare(n, text) == 0);
                    filterStartIndex = filterEndIndex - 4;
                    statement = statements.GetRange(filterStartIndex, filterEndIndex - filterStartIndex).ToArray();

                    if (statement[0].StartsWith("0") || statement[0].StartsWith("1"))
                    {
                        transactions.Add(new Statement()
                        {
                            PurchaseDate = Convert.ToDateTime(statement[0].Trim()),
                            Description = Convert.ToString(string.Concat(statement[1], " ", statement[2]).Trim()),
                            TransactionAmount = Convert.ToDecimal(statement[3].Trim()),
                            BalanceAmount = 0,
                            PostingDate = Convert.ToDateTime(statement[0].Trim()),
                            TransactionDate = Convert.ToDateTime(statement[0].Trim()),
                            AccountType = 3,
                            TransactionNumber = transactionNumber
                        });

                        transactionNumber += 1;
                        filterStartIndex = filterEndIndex;
                    }
                    else
                    {
                        filterStartIndex = filterEndIndex;
                    }
                }
            }

            return transactions;
        }
    }
}
