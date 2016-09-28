using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HFM.Business;
using HFM.Business.Data;

namespace HFM.Web.Models
{
    public class BankStatementModel
    {
        public int BankStatementId { get; set; }
        public int BankAccountTypeId { get; set; }
        public string BankAccountTypeName { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PostingDate { get; set; }
        public string TransactionDescription { get; set; }
        public int TransactionNumber { get; set; }
        public decimal Amount { get; set; }
        public decimal BalanceAmount { get; set; }

        public IList<BankStatementModel> GetBankStatementDetails()
        {
            var statement = new StatementFacade();
            var Statement = statement.GetStatements();
            return GetStatement(Statement);
        }

        public IList<BankStatementModel> GetBankStatementDetails(DateTime fromDate)
        {
            var statement = new StatementFacade();
            var Statement = statement.GetStatements();
            return GetStatement(Statement.Where(n => n.PaymentDate == fromDate));
        }

        public IList<BankStatementModel> GetBankStatementDetails(DateTime fromDate, DateTime toDate)
        {
            var statement = new StatementFacade();
            var Statement = statement.GetStatements();
            return GetStatement(Statement.Where(n => n.PaymentDate >= fromDate && n.PaymentDate <= toDate));
        }

        public bool AddStatement(BankStatementModel statement)
        {
            var isSaveSuccessful = false;
            var stat = new StatementFacade();
            var statements = new List<Statement>() as IList<Statement>;

            stat.AddStatements(new Statement()
            {
                BankAccountTypeId = statement.BankAccountTypeId,
                TransactionDate = statement.TransactionDate,
                PaymentDate = statement.PaymentDate,
                PostingDate = statement.PostingDate,
                TransactionDescription = statement.TransactionDescription,
                TransactionNumber = statement.TransactionNumber,
                Amount = statement.Amount,
                BalanceAmount = statement.BalanceAmount
            });

            return isSaveSuccessful;
        }

        public bool AddBulkStatements(IList<BankStatementModel> data)
        {
            var isSaveSuccessful = false;
            var stat = new StatementFacade();
            var statements = new List<Statement>() as IList<Statement>;

            foreach (var statement in data)
            {
                statements.Add(new Statement()
                {
                    BankAccountTypeId = statement.BankAccountTypeId,
                    TransactionDate = statement.TransactionDate,
                    PaymentDate = statement.PaymentDate,
                    PostingDate = statement.PostingDate,
                    TransactionDescription = statement.TransactionDescription,
                    TransactionNumber = statement.TransactionNumber,
                    Amount = statement.Amount,
                    BalanceAmount = statement.BalanceAmount
                });
            }

            //stat.AddStatements(statements);

            return isSaveSuccessful;
        }

        private IList<BankStatementModel> GetStatement(IEnumerable<Statement> transactions)
        {
            return transactions.Select(n => new BankStatementModel()
            {
                BankStatementId = n.BankStatementId,
                BankAccountTypeId = n.BankAccountTypeId,
                BankAccountTypeName = n.BankAccountTypeName,
                TransactionDate = n.TransactionDate,
                PaymentDate = n.PaymentDate,
                PostingDate = n.PostingDate,
                TransactionDescription = n.TransactionDescription,
                TransactionNumber = n.TransactionNumber,
                Amount = n.Amount,
                BalanceAmount = n.BalanceAmount
            }).ToList();
        }
    }
}