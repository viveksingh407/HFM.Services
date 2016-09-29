using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFM.Business.Data
{
    public class Statement
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
    }
}
