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
    public class PromitionsController : Controller
    {
        private ElectricStoreEntities db = new ElectricStoreEntities();

        // GET: Administrator/Promitions
        public ActionResult Index()
        {
            return View(db.Promitions.ToList());
        }

        // GET: Administrator/Promitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promition promition = db.Promitions.Find(id);
            if (promition == null)
            {
                return HttpNotFound();
            }
            return View(promition);
        }

        // GET: Administrator/Promitions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/Promitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PromotionId,PromotionName,PromotionDetails,PromotionDiscount,PromotionStatus,PromotionOpen,PromotionClose")] Promition promition)
        {
            if (ModelState.IsValid)
            {
                db.Promitions.Add(promition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promition);
        }

        // GET: Administrator/Promitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promition promition = db.Promitions.Find(id);
            if (promition == null)
            {
                return HttpNotFound();
            }
            return View(promition);
        }

        // POST: Administrator/Promitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PromotionId,PromotionName,PromotionDetails,PromotionDiscount,PromotionStatus,PromotionOpen,PromotionClose")] Promition promition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promition);
        }

        // GET: Administrator/Promitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promition promition = db.Promitions.Find(id);
            if (promition == null)
            {
                return HttpNotFound();
            }
            return View(promition);
        }

        // POST: Administrator/Promitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promition promition = db.Promitions.Find(id);
            db.Promitions.Remove(promition);
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
