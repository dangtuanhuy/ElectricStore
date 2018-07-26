using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopping.Models;
using System.IO;
using System.Data.Entity.Validation;

namespace EShopping.Areas.Administrator.Controllers
{
    public class ProductsController : Controller
    {
        private ElectricStoreEntities db = new ElectricStoreEntities();

        // GET: Administrator/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Color).Include(p => p.Size).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: Administrator/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Administrator/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.ColorId = new SelectList(db.Colors, "ColerId", "ColerName");
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Administrator/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProduceCode,ProductName,ProductDetails,ProductUpdate,ProductQty,ProductSold,SupplierId,CategoryId,ProductImg,ColorId,SizeId,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Code Upload File Basic
                    //Sử dụng thư viện System.IO
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var file = Request.Files[i];

                        if (file != null && file.ContentLength > 0)
                        {
                            if (file.ContentLength > 0)
                            {
                                string _FileName = Path.GetFileName(file.FileName);

                                string _path = Path.Combine(Server.MapPath("~/UploadImg/Products"), _FileName);
                                file.SaveAs(_path);
                                product.ProductImg = _FileName;
                            }
                        }
                    }
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColerId", "ColerName", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName", product.SizeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Administrator/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColerId", "ColerName", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName", product.SizeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: Administrator/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProduceCode,ProductName,ProductDetails,ProductUpdate,ProductQty,ProductSold,SupplierId,CategoryId,ProductImg,ColorId,SizeId,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColerId", "ColerName", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName", product.SizeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: Administrator/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Administrator/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Chỉnh sửa hình ảnh nếu không có hình thì upload hình nhé
        public ActionResult EditImg(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColerId", "ColerName", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName", product.SizeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }
        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditImg([Bind(Include = "ProductId,ProduceCode,ProductName,ProductDetails,ProductUpdate,ProductQty,ProductSold,SupplierId,CategoryId,ProductImg,ColorId,SizeId,ProductPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                //Sử dụng thư viện System.IO
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    if (file != null && file.ContentLength > 0)
                    {
                        if (file.ContentLength > 0)
                        {
                            string _FileName = Path.GetFileName(file.FileName);

                            string _path = Path.Combine(Server.MapPath("~/UploadImg/Products"), _FileName);
                            file.SaveAs(_path);
                            product.ProductImg = _FileName;
                        }
                    }
                }
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.ColorId = new SelectList(db.Colors, "ColerId", "ColerName", product.ColorId);
            ViewBag.SizeId = new SelectList(db.Sizes, "SizeId", "SizeName", product.SizeId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
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
