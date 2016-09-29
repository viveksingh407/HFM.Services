using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HFM.Business.Data;

namespace HFM.Business.Utilities
{
    public static class bofaCA
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
            public string PurchaseDate { get; set; }
            public string PostingDate { get; set; }
            public string Description { get; set; }
            public int TransactionNumber { get; set; }
            public int AccountNumber { get; set; }
            public decimal TransactionAmount { get; set; }
        }

        public static IList<Statement> FileQuery()
        {
            var statementPath = "M:\\Data\\HFM\\HFM Bank Statements\\eStmt_2016-07-15.txt";
            var completeStatementText = File.ReadAllLines(statementPath)
                    .Where(n => !string.IsNullOrEmpty(n))
                    .Select(n => n.TrimStart())
                    .ToList();

            var payments = GetPaymentsInfo(completeStatementText);
            var totalTax = GetTaxInfo(completeStatementText);
            var paymentAmount = GetTotalPaymentAmount(completeStatementText);
            var transactions = GetTransactions(completeStatementText);

            var totalCalculatedAmount = transactions.Select(n => n.TransactionAmount).Sum();

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
                        PurchaseDate = Convert.ToString(transactions[0]),
                        PostingDate = Convert.ToString(transactions[1]),
                        Description = string.Join(" ", transactions.Skip(2).Take((transactions.Count() - 3) - 2)),
                        TransactionNumber = Convert.ToInt32(transactions[transactions.Count() - 3]),
                        AccountNumber = Convert.ToInt32(transactions[transactions.Count() - 2]),
                        TransactionAmount = Convert.ToDecimal(transactions[transactions.Count() - 1])
                    });
                }
            }

            return data;
        }
    }
}
