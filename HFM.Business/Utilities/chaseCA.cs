using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

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

        public static IList<Statement> ChaseStatements()
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
                year = Path.GetFileName(statementPath).Substring(0, 4);
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

            if (transactions.Sum(n => n.BalanceAmount) != transactions.Last().BalanceAmount)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        private static Statement GetStatement(string year, string statement, int transactionIdentifier)
        {
            //statement = "06/19Card Purchase06/18 India Ld / Fcp 09162991011 CA Card 6066 -11.63 88.37";
            //var index = statement.IndexOf(@"/((.).*?){n}/") + 3;
            //string[] temp;
            string[] data = new string[4];

            //var data = statement.Remove(index, 1).Insert(index, "|").Replace("-", "|-").Insert(5, "|").Split(new char[] { '|' });

            //statement = statement.Remove(index, 1).Insert(index, "|").Insert(5, "|");

            //if (statement.Contains('-'))
            //{
            //    data = statement.Replace("-", "|-").Split(new char[] { '|' });
            //}
            //else
            //{
            //    temp = Regex.Split(statement, @"[^0-9\.]+");

            //    var amount = statement[statement.IndexOf(temp[temp.Length - 2]) - 1] == '-' ? string.Concat("-", temp[temp.Length - 2]) : temp[temp.Length - 2];

            //    data[0] = string.Concat(temp[0], "/", temp[1]);
            //    data[2] = amount;
            //    data[3] = temp[temp.Length - 1];
            //    data[1] = statement.Substring(6, (statement.IndexOf(amount) - 6));
            //}

            var mainStatement = statement;
            var transactionDate = Convert.ToDateTime(string.Concat(year, "/", statement.Substring(0, 5)));
            statement = statement.Substring(5, statement.Length - 5).Replace("  ", " ").Trim();


            var index = statement.Substring(0, statement.LastIndexOf(".")).LastIndexOf(".") + 3;
            var tempBalanceAmount = statement.Substring(index, ((statement.Length) - index)).Trim();
            statement = statement.Substring(0, index).Replace(",", string.Empty).Trim();

            var temp = Regex.Split(statement, @"[^0-9\.]+");

            var tempAmount = statement[statement.IndexOf(temp[temp.Length - 1]) - 1] == '-' ? string.Concat("-", temp[temp.Length - 1]) : temp[temp.Length - 1];
            var tempBalance = tempBalanceAmount.Replace(" ", string.Empty).Replace(",", string.Empty).Trim();

            //var transactionDate = Convert.ToDateTime(string.Concat(year, "/", temp[0], "/", temp[1]));
            var amount = Convert.ToDecimal(tempAmount.Trim());
            var balance = Convert.ToDecimal(tempBalance.Trim());
            var description = statement.Substring(0, statement.IndexOf(tempAmount)).Trim();

            //var transactionDate = Convert.ToDateTime(string.Concat(year, "/", data[0]));

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

        public static IList<Statement> FileQuery()
        {
            var statementPath = "M:\\Data\\HFM\\HFM Bank Statements\\chase statement.txt";

            var completeStatementText = File.ReadAllLines(statementPath)
                    .Where(n => !string.IsNullOrEmpty(n))
                    .Select(n => n.TrimStart())
                    .ToList();

            var transactions = new List<Statement>() as IList<Statement>;

            foreach (var individualTransaction in completeStatementText)
            {
                var list = individualTransaction.Split(new string[] { "||||" }, StringSplitOptions.RemoveEmptyEntries);

                transactions.Add(new Statement()
                {
                    PostingDate = Convert.ToDateTime(list[0]),
                    Description = list[1],
                    TransactionAmount = Convert.ToDecimal(list[2].Replace(" ", string.Empty)),
                    BalanceAmount = Convert.ToDecimal(list[3].Replace(" ", string.Empty))
                });
            }

            return transactions;
        }

        private static IList<Payments> GetPaymentsInfo(List<string> paymentDetails)
        {
            var data = new List<Payments>() as IList<Payments>;

            var paymentHeaderIdentifier = paymentDetails.IndexOf("Payments and Other Credits");
            var purchaseHeaderIdentifier = paymentDetails.IndexOf("Purchases and Adjustments");

            var payments = paymentDetails.Skip(paymentHeaderIdentifier + 1).Take((purchaseHeaderIdentifier - 2) - paymentHeaderIdentifier).ToList();

            foreach (var lineItem in payments)
            {
                var transactions = lineItem
                    .Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (transactions.Count() > 5)
                {
                    data.Add(new Payments()
                    {
                        PaymentDate = Convert.ToString(transactions[0]),
                        PostingDate = Convert.ToString(transactions[1]),
                        Description = string.Join(" ", transactions.Skip(2).Take((transactions.Count() - 3) - 2)),
                        TransactionNumber = Convert.ToInt32(transactions[transactions.Count() - 3]),
                        AccountNumber = Convert.ToInt32(transactions[transactions.Count() - 2]),
                        TransactionAmount = Convert.ToDecimal(transactions[transactions.Count() - 1].TrimStart().Substring(1))
                    });
                }
            }

            return data;
        }

        private static decimal GetTaxInfo(List<string> paymentDetails)
        {
            var interestHeaderIdentifier = paymentDetails.FindIndex(n => n.StartsWith("TOTAL INTEREST FOR THIS PERIOD"));
            var totalTax = Convert.ToDecimal(paymentDetails[interestHeaderIdentifier].Remove(0, "TOTAL INTEREST FOR THIS PERIOD".Length).TrimStart().Substring(1));

            return totalTax;
        }

        private static decimal GetTotalPaymentAmount(List<string> paymentDetails)
        {
            var interestHeaderIdentifier = paymentDetails.FindIndex(n => n.StartsWith("TOTAL INTEREST FOR THIS PERIOD"));
            var purchaseHeaderIdentifier = paymentDetails.IndexOf("Purchases and Adjustments");

            var totalTax = Convert.ToDecimal(paymentDetails[interestHeaderIdentifier].Remove(0, "TOTAL INTEREST FOR THIS PERIOD".Length).TrimStart().Substring(1));

            var totalPaymentAmountText = paymentDetails.Skip(purchaseHeaderIdentifier - 1).Take(1).First();
            var totalPaymentAmount = Convert.ToDecimal(totalPaymentAmountText.Substring(totalPaymentAmountText.IndexOf("$") + 1));

            return totalTax;
        }

        private static IList<Statement> GetTransactions(List<string> paymentDetails)
        {
            var data = new List<Statement>() as IList<Statement>;
            var purchaseHeaderIdentifier = paymentDetails.IndexOf("Purchases and Adjustments");

            var statement = paymentDetails
                .Skip(purchaseHeaderIdentifier + 1)
                .Where(n => (n.Contains("0723") || n.Contains("2680")) && n.Substring(0, 5).Contains("/"))
                .ToList();

            foreach (var lineItem in statement)
            {
                var transactions = lineItem
                    .Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (transactions.Count() > 5)
                {
                    data.Add(new Statement()
                    {
                        PurchaseDate = Convert.ToDateTime(transactions[0]),
                        PostingDate = Convert.ToDateTime(transactions[1]),
                        Description = string.Join(" ", transactions.Skip(2).Take((transactions.Count() - 3) - 2)),
                        TransactionNumber = Convert.ToInt32(transactions[transactions.Count() - 3]),
                        AccountType = Convert.ToInt32(transactions[transactions.Count() - 2]),
                        TransactionAmount = Convert.ToDecimal(transactions[transactions.Count() - 1])
                    });
                }
            }

            return data;
        }
    }
}
