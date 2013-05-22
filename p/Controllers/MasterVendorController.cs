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
                //vendor.Version = 1;
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
                //db.Configuration.ValidateOnSaveEnabled = true;
                db.Entry(vendor).State = EntityState.Modified;
                //db.SaveChanges();
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (TryUpdateModel(vendor, null, null, new[] { "Id", "Version" }))
                        //if (ModelState.IsValid)
                        //{
                        //    //vendor.Version += 1;
                        //    db.Vendors.Add(vendor);
                        db.SaveChanges();
                    //    return RedirectToAction("Index");
                    //}
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