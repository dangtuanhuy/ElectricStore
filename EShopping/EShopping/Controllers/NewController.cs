using EShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopping.Controllers
{
    public class NewController : Controller
    {
        ElectricStoreEntities db = new ElectricStoreEntities();
        // GET: New
        public ActionResult News()
        {
            var lstNew = db.News.OrderByDescending(n => n.NewsId).ToList();
            return View(lstNew);
        }
    }
}