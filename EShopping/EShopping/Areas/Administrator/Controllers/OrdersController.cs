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
    public class OrdersController : Controller
    {
        private ElectricStoreEntities db = new ElectricStoreEntities();

        // GET: Administrator/Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Employee).Include(o => o.Shipper);
            return View(orders.ToList());
        }

        // GET: Administrator/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Administrator/Orders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerCode = new SelectList(db.Customers, "CustomerCode", "CompanyName");
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass");
            ViewBag.ShipperId = new SelectList(db.Shippers, "ShipperId", "CompanyName");
            return View();
        }

        // POST: Administrator/Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,CustomerCode,EmployeeCode,OrderDate,RequiredDate,ShippedDate,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry,ShipperId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerCode = new SelectList(db.Customers, "CustomerCode", "CompanyName", order.CustomerCode);
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass", order.EmployeeCode);
            ViewBag.ShipperId = new SelectList(db.Shippers, "ShipperId", "CompanyName", order.ShipperId);
            return View(order);
        }

        // GET: Administrator/Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerCode = new SelectList(db.Customers, "CustomerCode", "CompanyName", order.CustomerCode);
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass", order.EmployeeCode);
            ViewBag.ShipperId = new SelectList(db.Shippers, "ShipperId", "CompanyName", order.ShipperId);
            return View(order);
        }

        // POST: Administrator/Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerCode,EmployeeCode,OrderDate,RequiredDate,ShippedDate,Freight,ShipName,ShipAddress,ShipCity,ShipRegion,ShipPostalCode,ShipCountry,ShipperId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerCode = new SelectList(db.Customers, "CustomerCode", "CompanyName", order.CustomerCode);
            ViewBag.EmployeeCode = new SelectList(db.Employees, "EmployeeCode", "EmployeePass", order.EmployeeCode);
            ViewBag.ShipperId = new SelectList(db.Shippers, "ShipperId", "CompanyName", order.ShipperId);
            return View(order);
        }

        // GET: Administrator/Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Administrator/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
