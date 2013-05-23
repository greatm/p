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
            var lastVersionVendors = from n in db.Vendors
                                     group n by n.ID into g
                                     select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersionVendors.ToList());
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
                int iId = 1;
                try
                {
                    iId = db.Vendors.Max(t => t.ID) + 1;
                }
                catch { }
                vendor.ID = iId;
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
                //db.Entry(vendor).State = EntityState.Modified;
                try
                {
                    Vendor vendorV = new Vendor
                    {
                        ID = vendor.ID,
                        Version = vendor.Version + 1,
                        Timestamp = vendor.Timestamp,
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
                    db.Vendors.Add(vendorV);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    Vendor vendorV = new Vendor
                    {
                        ID = vendor.ID,
                        Version = vendor.Version + 1,
                        Timestamp = vendor.Timestamp,
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
                    db.Vendors.Add(vendorV);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(vendor);
        }

        //
        // GET: /MasterVendor/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Vendor vendor = db.Vendors.Find(id, version);
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