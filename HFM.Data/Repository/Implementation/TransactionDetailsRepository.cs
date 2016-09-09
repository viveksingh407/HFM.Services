using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class TransactionDetailsRepository : IHFMRepository
    {
        public int TransactionDetailsId { get; set; }
        public string TransactionDetailsName { get; set; }
        public ExpenseAmountType ExpenseAmountType { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public TransactionCategory TransactionCategory { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        private static HFMDBEntities context;

        public IList<TransactionDetailsRepository> Get()
        {
            TransactionDetailsRepository repo = new TransactionDetailsRepository();
            context = new HFMDBEntities();

            return context.TransactionDetails.Select(n => new TransactionDetailsRepository()
            {
                TransactionDetailsId = n.TransactionDetailsId,
                TransactionDetailsName = n.TransactionDetailsName
            }).ToList();
        }
    }
}
