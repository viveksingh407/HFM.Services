using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HFM.Web.Models;

namespace HFM.Web.Controllers
{
    public class HFMController : Controller
    {
        // GET: HFM
        public ActionResult Index()
        {
            TransactionDetails details = new TransactionDetails();

            details.GetTransactionDetails();
            return View(details);
        }

        [HttpPut]
        public void Add(TransactionDetail detail)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.AddTransactionDetails(detail);
        }

        [HttpPost]
        public string Update(TransactionDetail detail)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.UpdateTransactionDetails(detail);

            return "Sucess";
        }

        [HttpDelete]
        public void Delete(int transactionId)
        {
            TransactionDetail detail = new TransactionDetail();
            detail.DeleteTransactionDetails(transactionId);
        }
    }
}