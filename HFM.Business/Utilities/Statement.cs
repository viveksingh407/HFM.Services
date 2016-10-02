using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFM.Business.Utilities
{
    public class Statement
    {
        public DateTime PurchaseDate { get; set; }
        public DateTime PostingDate { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public int TransactionNumber { get; set; }
        public int AccountType { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal BalanceAmount { get; set; }
    }
}
