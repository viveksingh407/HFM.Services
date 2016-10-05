using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HFM.Business.Data;
using System.Text.RegularExpressions;
using HFM.Data.Repository.Implementation;

namespace HFM.Business.Utilities
{
    public static class bofaCA
    {
        public static IList<Statement> BofAStatements(bool addToDB)
        {
            var statementText = new List<string>();
            var transactions = new List<Statement>() as IList<Statement>;
            var allTransactions = new List<Statement>() as IList<Statement>;
            var statements = new List<string>() as IList<string>;
            var allStatements = new List<string>() as IList<string>;
            var path = @"M:\Data\Bank Statements\BofA\Checking\Text";

            var startIndex = -1;
            var endIndex = -1;

            var statementPaths = Directory.GetFiles(path, "*.txt");

            var year = string.Empty;

            foreach (var statementPath in statementPaths)
            {
                year = Regex.Split(Path.GetFileName(statementPath), @"[^0-9\.]+").Where(n => n.StartsWith("201")).FirstOrDefault();
                statementText = File.ReadAllLines(statementPath).Where(n => !string.IsNullOrEmpty(n)).Select(n => n.Trim()).ToList();

                startIndex = statementText.FindIndex(n => n.StartsWith("Your checking account"));
                endIndex = statementText.Count() - 1;

                GetDeposits(statementText.GetRange(startIndex, endIndex - startIndex));

            }
            return transactions;
        }

        private static IList<string> GetDeposits(List<string> depositTransactionBlock)
        {
            var depositList = new List<string>() as IList<string>;

            var startIndex = depositTransactionBlock.IndexOf("Deposits and other additions") + 2;
            var endIndex = depositTransactionBlock.IndexOf("Withdrawals and other subtractions", startIndex);

            var deposits = depositTransactionBlock.GetRange(startIndex, endIndex - startIndex);

            deposits.Remove("Withdrawals and other subtractions");
            deposits.Remove(deposits.Find(n => n.StartsWith("Withdrawals and other subtractions")));
            deposits.Remove(deposits.Find(n => n.StartsWith("$")));
            deposits.Remove(deposits.Find(n => n.StartsWith("Total deposits and other additions")));
            deposits.Remove(deposits.Find(n => n.StartsWith("Amount")));

            var description = new List<string>() as IList<string>;
            var extraDescription = new List<string>() as IList<string>;
            var cost = new List<string>() as IList<string>;
            var tempDeposit = string.Empty;

            foreach (var deposit in deposits)
            {
                double temp = 0.0;

                if (deposit.Contains("/"))
                {
                    var tempAll = deposit.Trim().Split(new char[] { ' ' });
                    tempDeposit = deposit;

                    if (double.TryParse(tempAll[tempAll.Length - 1], out temp))
                    {
                        cost.Add(tempAll[tempAll.Length - 1]);
                        tempDeposit = deposit.Replace(tempAll[tempAll.Length - 1], string.Empty);
                    }

                    description.Add(tempDeposit);
                }
                else if (double.TryParse(deposit, out temp))
                {
                    cost.Add(Convert.ToString(temp));
                }
                else
                {
                    extraDescription.Add(deposit);
                }
            }

            int count = 0;
            var tempFirstDescription = string.Empty;
            var tempDescription = string.Empty;
            var tempCost = string.Empty;

            foreach (var all in description)
            {
                tempFirstDescription = string.Empty;
                tempDescription = string.Empty;
                tempCost = string.Empty;

                if (extraDescription.Any() && extraDescription.Count() >= count - 1)
                {
                    tempDescription = string.Concat(extraDescription[count], " ");
                    extraDescription.RemoveAt(count);
                }

                if (cost.Any() && cost.Count() >= count - 1)
                {
                    tempCost = cost[count];
                    cost.RemoveAt(count);
                }

                tempFirstDescription = string.Concat(all, " ");

                depositList.Add(string.Concat(tempFirstDescription, tempDescription, tempCost).Trim());
            }

            return depositList;
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
