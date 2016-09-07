using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFM.Web.Models
{
    public class TransactionDetails
    {
        public IList<TransactionDetail> FinanceTransactionDetails { get; set; }

        private static TransactionDetail detail;

        public void GetTransactionDetails()
        {
            detail = new TransactionDetail();
            this.FinanceTransactionDetails = detail.GetTransactionDetails();
        }
    }
}