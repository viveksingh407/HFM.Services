using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HFM.Web.Models;
using Newtonsoft.Json;

namespace HFM.Web.Controllers
{
    public class BankStatementsController : Controller
    {
        // GET: BankStatements
        public ActionResult Index()
        {
            BankStatementModel model = new BankStatementModel();
            var data = model.GetBankStatementDetails();
            //bofaCA.FileQuery();
            return View(data);
        }

        [HttpGet]
        public JsonResult GetStatements()
        {
            BankStatementModel model = new BankStatementModel();
            var data = model.GetBankStatementDetails();
            var serializedTransactionData = JsonConvert.SerializeObject(data);

            return new JsonResult() { Data = serializedTransactionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetStatementsByDate(DateTime fromDate)
        {
            BankStatementModel model = new BankStatementModel();
            var data = model.GetBankStatementDetails(fromDate);
            var serializedTransactionData = JsonConvert.SerializeObject(data);

            return new JsonResult() { Data = serializedTransactionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public JsonResult GetStatementsBetweenDates(DateTime fromDate, DateTime toDate)
        {
            BankStatementModel model = new BankStatementModel();
            var data = model.GetBankStatementDetails(fromDate, toDate);
            var serializedTransactionData = JsonConvert.SerializeObject(data);

            return new JsonResult() { Data = serializedTransactionData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult AddStatement(BankStatementModel data)
        {
            BankStatementModel model = new BankStatementModel();
            model.AddStatement(data);

            var transactions = model.GetBankStatementDetails(DateTime.Today);

            return PartialView("Statements", transactions);
        }
    }
}