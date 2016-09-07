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
    }
}