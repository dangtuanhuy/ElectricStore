using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopping.Models;

namespace EShopping.Controllers
{
    public class MNCategoriesController : Controller
    {
        // GET: MNCategories
        public ActionResult Index()
        {
            ElectricStoreEntities db = new ElectricStoreEntities();
            var lstCate = from CAT in db.Categories select CAT;
            return View(lstCate);
        }
    }
}