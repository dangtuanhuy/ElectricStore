using EShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EShopping.Controllers
{
    public class ContactController : Controller
    {
        private ElectricStoreEntities db = new ElectricStoreEntities();
        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "ContactId,CompanyName,ContactName,Address,City,Region,PostalCode,Country,Phone,Extension,Fax,Status")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return View ("~/Views/Home/Index.cshtml");

            }

            return View(contact);
        }

    }
}