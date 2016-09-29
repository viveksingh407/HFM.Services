using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.Repository.Implementation;

namespace HFM.Business
{
    public class HFMTransactionDetails
    {
        public int TransactionDetailsId { get; set; }
        public string TransactionDetailsName { get; set; }
        //public ExpenseAmountType ExpenseAmountType { get; set; }
        //public ExpenseType ExpenseType { get; set; }
        //public TransactionCategory TransactionCategory { get; set; }
        //public TransactionType TransactionType { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        private static TransactionDetailsRepository repo;

        public IList<HFMTransactionDetails> GetTransactionDetails()
        {
            repo = new TransactionDetailsRepository();
            var details = repo.Get();

            return details.Select(n => new HFMTransactionDetails()
            {
                TransactionDetailsId = n.TransactionDetailsId,
                TransactionDetailsName = n.TransactionDetailsName
            }).ToList();
        }

        public void AddTransactionDetails(HFMTransactionDetails details)
        {
            var repo = new TransactionDetailsRepository()
            {
                TransactionDetailsId = details.TransactionDetailsId,
                TransactionDetailsName = details.TransactionDetailsName
            };

            repo.Add(repo);
        }

        public void UpdateTransactionDetails(HFMTransactionDetails details)
        {
            var repo = new TransactionDetailsRepository()
            {
                TransactionDetailsId = details.TransactionDetailsId,
                TransactionDetailsName = details.TransactionDetailsName
            };

            repo.Update(repo);
        }

        public void DeleteTransactionDetails(int transactionDetailsId)
        {
            repo = new TransactionDetailsRepository();

            repo.Delete(transactionDetailsId);
        }
    }
}
