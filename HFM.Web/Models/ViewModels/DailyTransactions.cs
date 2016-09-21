using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFM.Web.Models.ViewModels
{
    public class DailyTransactions
    {
        public IList<DailyTransactionsModel> Transactions { get; set; }
    }
}