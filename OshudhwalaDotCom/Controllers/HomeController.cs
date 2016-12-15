using OshudhwalaDotCom.Core.BLL;
using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshudhwalaDotCom.Controllers
{
    public class HomeController : Controller
    {
        ItemManager itemManager = new ItemManager();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult SearchByText(string searchItem)
        {
            List<Item> items = new List<Item>();
            if (searchItem != "")
            {                
                items = itemManager.GetItemsByText(searchItem);
            }
            return View(items);
        } 
    }
}