using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshudhwalaDotCom.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult BKash()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BKash(Payment payment)
        {
            return View();
        }
    }
}