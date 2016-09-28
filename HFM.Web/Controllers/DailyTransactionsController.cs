using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using HFM.Web.Models;
using HFM.Business.Utilities;

namespace HFM.Web.Controllers
{
    public class DailyTransactionsController : Controller
    {
        // GET: DailyTransactions
        public ActionResult Index()
        {
            DailyTransactionsModel model = new DailyTransactionsModel();
            var data = model.GetDailyTransactions();
            //bofaCA.FileQuery();
            return View(data);
        }

        [HttpGet]
        public JsonResult GetDailyTransactions()
        {
            DailyTransactionsModel model = new DailyTransactionsModel();
            var data = model.GetDailyTransactions();
            var serializedTransactionData = JsonConvert.SerializeObject(data);

            return new JsonResult() { Data = serializedTransactionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetDailyTransactionsByDate(DateTime purchasedDate)
        {
            DailyTransactionsModel model = new DailyTransactionsModel();
            var data = model.GetDailyTransactions(purchasedDate);
            var serializedTransactionData = JsonConvert.SerializeObject(data);

            return new JsonResult() { Data = serializedTransactionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetDailyTransactionsBetweenDates(DateTime purchasedFromDate, DateTime purchasedToDate)
        {
            DailyTransactionsModel model = new DailyTransactionsModel();
            var data = model.GetDailyTransactions(purchasedFromDate, purchasedToDate);
            var serializedTransactionData = JsonConvert.SerializeObject(data);

            return new JsonResult() { Data = serializedTransactionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult AddDailyTransaction(DailyTransactionsModel data)
        {
            DailyTransactionsModel model = new DailyTransactionsModel();
            model.AddDailyTransaction(data);

            var transactions = model.GetDailyTransactions(DateTime.Today);

            return PartialView("Items", transactions);
        }
    }
}