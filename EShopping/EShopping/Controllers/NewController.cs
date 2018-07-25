using EShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace EShopping.Controllers
{
    public class NewController : Controller
    {
        ElectricStoreEntities db = new ElectricStoreEntities();
        // GET: New
        public ActionResult News(string sortOrder, string searchString, int? page, string currentFilter)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            var lstNew = from s in db.News
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                lstNew = lstNew.Where(s => s.NewTitles.Contains(searchString)
                                       || s.NewsBy.Contains(searchString));
            }
            
                    lstNew = lstNew.OrderBy(s => s.NewUpdate);
                    int pageSize = 3;
                    int pageNumber = (page ?? 1);
                    return View(lstNew.ToPagedList(pageNumber, pageSize));
        }
    }
}