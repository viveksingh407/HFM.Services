using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HFM.Business;

namespace HFM.Web.Models
{
    public class TransactionDetail
    {
        public int TransactionDetailsId { get; set; }
        public string TransactionDetailsName { get; set; }
        //public ExpenseAmountType ExpenseAmountType { get; set; }
        //public ExpenseType ExpenseType { get; set; }
        //public TransactionCategory TransactionCategory { get; set; }
        //public TransactionType TransactionType { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

        private static HFMTransactionDetails details;

        public IList<TransactionDetail> GetTransactionDetails()
        {
            details = new HFMTransactionDetails();
            var transctionDetails = details.GetTransactionDetails();

            return transctionDetails.Select(n => new TransactionDetail()
            {
                TransactionDetailsId = n.TransactionDetailsId,
                TransactionDetailsName = n.TransactionDetailsName
            }).ToList();
        }

        public void AddTransactionDetails(TransactionDetail detail)
        {
            details = new HFMTransactionDetails()
            {
                TransactionDetailsId = detail.TransactionDetailsId,
                TransactionDetailsName = detail.TransactionDetailsName
            };

            details.AddTransactionDetails(details);
        }

        public void UpdateTransactionDetails(TransactionDetail detail)
        {
            details = new HFMTransactionDetails()
            {
                TransactionDetailsId = detail.TransactionDetailsId,
                TransactionDetailsName = detail.TransactionDetailsName
            };

            details.UpdateTransactionDetails(details);
        }

        public void DeleteTransactionDetails(int id)
        {
            details.DeleteTransactionDetails(id);
        }
    }
}