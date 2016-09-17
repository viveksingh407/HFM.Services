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
        TransactionDetails details;

        // GET: HFM
        public ActionResult Index()
        {
            this.GetTransactionDetails();
            return View(details);
        }

        [HttpPut]
        public void Add(TransactionDetail detail)
        {
            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.AddTransactionDetails(detail);
        }

        [HttpPost]
        public ActionResult Update(TransactionDetail detail)
        {
            var transactionDetails = new TransactionDetail();
            transactionDetails.UpdateTransactionDetails(detail);

            this.GetTransactionDetails();
            
            return PartialView("TransactionDetails", details);
        }

        [HttpDelete]
        public void Delete(int transactionId)
        {
            var transactionDetails = new TransactionDetail();
            transactionDetails.DeleteTransactionDetails(transactionId);
        }

        private void GetTransactionDetails()
        {
            details = new TransactionDetails();
            details.GetTransactionDetails();
        }
    }
}