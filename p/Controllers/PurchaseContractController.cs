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
    public class PurchaseContractController : Controller
    {
        private ContextP db = new ContextP();

        //
        // GET: /PurchaseContract/

        public ActionResult Index()
        {
            return View(db.Contracts.ToList());
        }

        //
        // GET: /PurchaseContract/Details/5

        public ActionResult Details(int id = 0)
        {
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        //
        // GET: /PurchaseContract/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PurchaseContract/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contract);
        }

        //
        // GET: /PurchaseContract/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        //
        // POST: /PurchaseContract/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contract contract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        //
        // GET: /PurchaseContract/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        //
        // POST: /PurchaseContract/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
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