using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p.Models;
using System.Data.Entity.Infrastructure;

namespace p.Controllers
{
    public class MasterVendorController : Controller
    {
        private ContextP db = new ContextP();

        //
        // GET: /MasterVendor/

        public ActionResult Index()
        {
            return View(db.Vendors.ToList());
        }

        //
        // GET: /MasterVendor/Details/5

        public ActionResult Details(int id = 0, int version = 0)
        {
            Vendor vendor = db.Vendors.Find(id, version);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // GET: /MasterVendor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MasterVendor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                int iId = db.Vendors.Max(t => t.ID);
                vendor.ID = iId + 1;
                vendor.Version = 1;
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        //
        // GET: /MasterVendor/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Vendor vendor = db.Vendors.Find(id, version);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // POST: /MasterVendor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendor).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Vendor vendorV = new Vendor
                    {
                        ID = vendor.ID,
                        Version = vendor.Version + 1,
                        //Timestamp = vendor.Timestamp,
                        Name = vendor.Name,
                        Person = vendor.Person,
                        Address = vendor.Address,
                        City = vendor.City,
                        State = vendor.State,
                        PostalCode = vendor.PostalCode,
                        Country = vendor.Country,
                        Mobile = vendor.Mobile,
                        Phone = vendor.Phone,
                        eMail = vendor.eMail,
                        WebSite = vendor.WebSite,
                        Remarks = vendor.Remarks
                    };
                    //vendor.Version += 1;
                    db.Vendors.Add(vendorV);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        //
        // GET: /MasterVendor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        //
        // POST: /MasterVendor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vendor vendor = db.Vendors.Find(id);
            db.Vendors.Remove(vendor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}