using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p.Models;

namespace p.Controllers
{
    public class PurchaseGrnController : Controller
    {
        private ContextP db = new ContextP();

        //
        // GET: /PurchaseGrn/

        public ActionResult Index()
        {
            return View(db.GRNs.ToList());
        }

        //
        // GET: /PurchaseGrn/Details/5

        public ActionResult Details(int id = 0)
        {
            GRN grn = db.GRNs.Find(id);
            if (grn == null)
            {
                return HttpNotFound();
            }
            return View(grn);
        }

        //
        // GET: /PurchaseGrn/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PurchaseGrn/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GRN grn)
        {
            if (ModelState.IsValid)
            {
                db.GRNs.Add(grn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grn);
        }

        //
        // GET: /PurchaseGrn/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GRN grn = db.GRNs.Find(id);
            if (grn == null)
            {
                return HttpNotFound();
            }
            return View(grn);
        }

        //
        // POST: /PurchaseGrn/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GRN grn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grn);
        }

        //
        // GET: /PurchaseGrn/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GRN grn = db.GRNs.Find(id);
            if (grn == null)
            {
                return HttpNotFound();
            }
            return View(grn);
        }

        //
        // POST: /PurchaseGrn/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GRN grn = db.GRNs.Find(id);
            db.GRNs.Remove(grn);
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