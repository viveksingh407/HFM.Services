using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Business.Data;
using HFM.Data.Repository.Implementation;

namespace HFM.Business
{
    public class StatementFacade
    {
        private BankStatementsRepository repo;

        public IList<Statement> GetStatements()
        {
            repo = new BankStatementsRepository();
            var details = repo.Get();

            return details.Select(n => new Statement()
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

        public void AddStatements(Statement details)
        {
            var repo = new BankStatementsRepository()
            {
                BankAccountTypeId = details.BankAccountTypeId,
                BankAccountTypeName = details.BankAccountTypeName,
                TransactionDate = details.TransactionDate,
                PaymentDate = details.PaymentDate,
                PostingDate = details.PostingDate,
                TransactionDescription = details.TransactionDescription,
                TransactionNumber = details.TransactionNumber,
                Amount = details.Amount,
                BalanceAmount = details.BalanceAmount
            };

            repo.Add(repo);
        }

        public void UpdateBankStatements(Statement details)
        {
            var repo = new BankStatementsRepository()
            {
                BankAccountTypeId = details.BankAccountTypeId,
                BankAccountTypeName = details.BankAccountTypeName,
                TransactionDate = details.TransactionDate,
                PaymentDate = details.PaymentDate,
                PostingDate = details.PostingDate,
                TransactionDescription = details.TransactionDescription,
                TransactionNumber = details.TransactionNumber,
                Amount = details.Amount,
                BalanceAmount = details.BalanceAmount
            };

            repo.Add(repo);
        }

        public void DeleteBankStatements(int statementId)
        {
            repo = new BankStatementsRepository();
            repo.Delete(statementId);
        }
    }
}
