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
        public ActionResult News(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var lstNew = from s in db.News
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstNew = lstNew.Where(s => s.NewTitles.Contains(searchString)
                                       || s.NewsBy.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    lstNew = lstNew.OrderByDescending(s => s.NewsId);
                    break;
            }
            return View(lstNew);
        }
    }
}