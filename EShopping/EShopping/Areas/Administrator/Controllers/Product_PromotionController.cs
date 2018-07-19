using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopping.Models;

namespace EShopping.Areas.Administrator.Controllers
{
    public class Product_PromotionController : Controller
    {
        private ElectricStoreEntities db = new ElectricStoreEntities();

        // GET: Administrator/Product_Promotion
        public ActionResult Index()
        {
            var product_Promotion = db.Product_Promotion.Include(p => p.Product).Include(p => p.Promition);
            return View(product_Promotion.ToList());
        }

        // GET: Administrator/Product_Promotion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Promotion product_Promotion = db.Product_Promotion.Find(id);
            if (product_Promotion == null)
            {
                return HttpNotFound();
            }
            return View(product_Promotion);
        }

        // GET: Administrator/Product_Promotion/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode");
            ViewBag.PromotionId = new SelectList(db.Promitions, "PromotionId", "PromotionName");
            return View();
        }

        // POST: Administrator/Product_Promotion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PromotionId,ProductId,Gift")] Product_Promotion product_Promotion)
        {
            if (ModelState.IsValid)
            {
                db.Product_Promotion.Add(product_Promotion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode", product_Promotion.ProductId);
            ViewBag.PromotionId = new SelectList(db.Promitions, "PromotionId", "PromotionName", product_Promotion.PromotionId);
            return View(product_Promotion);
        }

        // GET: Administrator/Product_Promotion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Promotion product_Promotion = db.Product_Promotion.Find(id);
            if (product_Promotion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode", product_Promotion.ProductId);
            ViewBag.PromotionId = new SelectList(db.Promitions, "PromotionId", "PromotionName", product_Promotion.PromotionId);
            return View(product_Promotion);
        }

        // POST: Administrator/Product_Promotion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PromotionId,ProductId,Gift")] Product_Promotion product_Promotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Promotion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProduceCode", product_Promotion.ProductId);
            ViewBag.PromotionId = new SelectList(db.Promitions, "PromotionId", "PromotionName", product_Promotion.PromotionId);
            return View(product_Promotion);
        }

        // GET: Administrator/Product_Promotion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Promotion product_Promotion = db.Product_Promotion.Find(id);
            if (product_Promotion == null)
            {
                return HttpNotFound();
            }
            return View(product_Promotion);
        }

        // POST: Administrator/Product_Promotion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Promotion product_Promotion = db.Product_Promotion.Find(id);
            db.Product_Promotion.Remove(product_Promotion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
