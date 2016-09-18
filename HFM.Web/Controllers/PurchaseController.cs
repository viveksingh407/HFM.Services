using HFM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFM.Web.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetItems(string query)
        {
            //var data = new string[] { "One", "Two", "Three", "Four"};
            var data = this.GetTransactionDetails();
            string[] filteredData;

            if (!string.IsNullOrEmpty(query))
            {
                filteredData = data.Where(n => n.StartsWith(query, StringComparison.InvariantCultureIgnoreCase)).ToArray();
            }
            else
            {
                filteredData = data;
            }

            return new JsonResult() { Data = filteredData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        private string[] GetTransactionDetails()
        {
            var details = new TransactionDetails();
            details.GetTransactionDetails();

            return details.FinanceTransactionDetails.Select(n => n.TransactionDetailsName).ToArray();
        }
    }
}