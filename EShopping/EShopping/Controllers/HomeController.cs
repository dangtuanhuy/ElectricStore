using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EShopping.Models;

namespace EShopping.Controllers
{
    public class HomeController : Controller
    {
        private ElectricStoreEntities db = new ElectricStoreEntities();
        public ActionResult Index()
        {
            var lstProduct = db.Products.Where(n => n.CategoryId == 1 && n.ProductSold == false);
            ViewBag.ListProduct = lstProduct;
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
        public ActionResult Branch()
        {
            ViewBag.Branchs = db.Branches.ToList();
            return PartialView("_BranchPartial");
        }
        public ActionResult Category()
        {
            ViewBag.Categories = db.Categories.ToList();
            //var lstCate = from CAT in db.Categories select CAT;
            return PartialView("_CategoryPartial");
        }
        public ActionResult ProductStyle1Partial()
        {
            return PartialView();
        }
    }
}