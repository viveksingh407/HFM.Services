using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFM.Data.EF;

namespace HFM.Data.Repository.Implementation
{
    public class TransactionDetailsRepository : IHFMRepository<TransactionDetailsRepository>
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

        public TransactionDetailsRepository GetById(int id)
        {
            TransactionDetailsRepository repo = new TransactionDetailsRepository();
            context = new HFMDBEntities();

            return context.TransactionDetails.Where(n => n.TransactionCategoryId == id).Select(n => new TransactionDetailsRepository()
            {
                TransactionDetailsId = n.TransactionDetailsId,
                TransactionDetailsName = n.TransactionDetailsName
            }).FirstOrDefault();
        }

        public TransactionDetailsRepository Add(TransactionDetailsRepository data)
        {
            TransactionDetailsRepository repo = new TransactionDetailsRepository();
            context = new HFMDBEntities();

            context.TransactionDetails.Add(new TransactionDetail()
            {
                TransactionDetailsId = data.TransactionDetailsId,
                TransactionDetailsName = data.TransactionDetailsName
            });

            return data;
        }

        public TransactionDetailsRepository Update(TransactionDetailsRepository data)
        {
            TransactionDetailsRepository repo = new TransactionDetailsRepository();
            context = new HFMDBEntities();

            try
            {
                var details = context.TransactionDetails.Where(n => n.TransactionDetailsId == data.TransactionDetailsId).First();
                
                details.TransactionDetailsName = data.TransactionDetailsName;

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
            TransactionDetailsRepository repo = new TransactionDetailsRepository();
            context = new HFMDBEntities();

            var details = context.TransactionDetails.Where(n => n.TransactionCategoryId == id).First();

            context.TransactionDetails.Remove(details);
        }
    }
}
