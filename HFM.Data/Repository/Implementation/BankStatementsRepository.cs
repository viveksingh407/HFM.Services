using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class BankStatementsRepository
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

        private static HFMDBEntities context;

        public IList<BankStatementsRepository> Get()
        {
            BankStatementsRepository repo = new BankStatementsRepository();
            context = new HFMDBEntities();

            var data = (from a in context.BankStatements
                        join b in context.BankAccountTypes on a.BankAccountTypeId equals b.BankAccountTypeId
                        select new BankStatementsRepository()
                        {
                            BankStatementId = a.BankStatementId,
                            BankAccountTypeId = a.BankAccountTypeId,
                            BankAccountTypeName = b.BankAccountTypeName,
                            TransactionDate = a.TransactionDate,
                            PaymentDate = a.PaymentDate ?? default(DateTime),
                            PostingDate = a.PostingDate,
                            TransactionDescription = a.TransactionDescription,
                            TransactionNumber = a.TransacionNumber ?? default(int),
                            Amount = a.Amount,
                            BalanceAmount = a.BalanceAmount ?? default(decimal)
                        });

            return data.ToList();
        }

        public BankStatementsRepository GetById(int dailyPurchaseId)
        {
            BankStatementsRepository repo = new BankStatementsRepository();
            context = new HFMDBEntities();

            var data = (from a in context.BankStatements
                        join b in context.BankAccountTypes on a.BankAccountTypeId equals b.BankAccountTypeId
                        select new BankStatementsRepository()
                        {
                            BankStatementId = a.BankStatementId,
                            BankAccountTypeId = a.BankAccountTypeId,
                            BankAccountTypeName = b.BankAccountTypeName,
                            TransactionDate = a.TransactionDate,
                            PaymentDate = a.PaymentDate ?? default(DateTime),
                            PostingDate = a.PostingDate,
                            TransactionDescription = a.TransactionDescription,
                            TransactionNumber = a.TransacionNumber ?? default(int),
                            Amount = a.Amount,
                            BalanceAmount = a.BalanceAmount ?? default(decimal)
                        }).FirstOrDefault();

            return data;
        }

        public BankStatementsRepository Add(BankStatementsRepository data)
        {
            BankStatementsRepository repo = new BankStatementsRepository();
            context = new HFMDBEntities();

            context.BankStatements.Add(new BankStatement()
            {
                BankAccountTypeId = BankAccountTypeId,
                TransactionDate = TransactionDate,
                PaymentDate = PaymentDate,
                PostingDate = PostingDate,
                TransactionDescription = TransactionDescription,
                TransacionNumber = TransactionNumber,
                Amount = Amount,
                BalanceAmount = BalanceAmount
            });

            context.SaveChanges();

            return data;
        }

        public BankStatementsRepository Update(BankStatementsRepository data)
        {
            BankStatementsRepository repo = new BankStatementsRepository();
            context = new HFMDBEntities();

            try
            {
                var details = context.BankStatements.Where(n => n.BankStatementId == data.BankStatementId).First();
                
                details.BankAccountTypeId = data.BankAccountTypeId;
                details.TransactionDate = data.TransactionDate;
                details.PaymentDate = data.PaymentDate;
                details.PostingDate = data.PostingDate;
                details.TransactionDescription = data.TransactionDescription;
                details.TransacionNumber = data.TransactionNumber;
                details.Amount = data.Amount;
                details.BalanceAmount = data.BalanceAmount;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

        public void Delete(int id)
        {
            BankStatementsRepository repo = new BankStatementsRepository();
            context = new HFMDBEntities();

            var details = context.BankStatements.Where(n => n.BankStatementId == id).First();

            context.BankStatements.Remove(details);
        }
    }
}
