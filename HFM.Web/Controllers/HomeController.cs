using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HFM.Business;

namespace HFM.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HFMTransactionDetails details = new HFMTransactionDetails();

            var a = details.GetTransactionDetails();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}