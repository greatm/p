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

        public ActionResult Index()
        {
            var lastVersionVendors = from n in db.Vendors
                                     group n by n.ID into g
                                     select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersionVendors.ToList());
        }

        public ActionResult Details(int id = 0, int version = 0)
        {
            Vendor vendor = db.Vendors.Find(id, version);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Vendors.Max(t => t.ID) + 1;
                }
                catch { }
                vendor.ID = iId;
                vendor.Version = 1;
                vendor.EntryDate = DateTime.Now;
                db.Vendors.Add(vendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendor);
        }

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Vendor vendor = db.Vendors.Find(id, version);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                Vendor newItem = vendor;
                newItem.Version = vendor.Version + 1;
                newItem.EntryDate = DateTime.Now;
                db.Vendors.Add(newItem);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Vendor vendor = db.Vendors.Find(id, version);
            if (vendor == null)
            {
                return HttpNotFound();
            }
            return View(vendor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            Vendor vendor = db.Vendors.Find(id, version);
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