using FeinxZone.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeinxZone.Controllers
{
    public class HomeController : Controller
    {
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [Auth]
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

        [Auth]
        public ActionResult TransferMoney()
        {
            return View();
        }

        [HttpPost]
        [Auth]
        [ValidateAntiForgeryToken]
        public ActionResult TransferMoney(string toAccount, decimal money)
        {
            ViewBag.ToAccount = toAccount;
            ViewBag.Money = money;
            return View();
        }
    }
}