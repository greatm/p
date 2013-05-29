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
    public class PaymentIssueController : Controller
    {
        private ContextP db = new ContextP();

        public ActionResult Index()
        {
            var lastVersions = from n in db.Payments
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions);
        }

        //
        // GET: /PaymentIssue/Details/5

        public ActionResult Details(int id = 0, int version = 0)
        {
            Payment payment = db.Payments.Find(id, version);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // GET: /PaymentIssue/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PaymentIssue/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(payment);
        }

        //
        // GET: /PaymentIssue/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Payment payment = db.Payments.Find(id, version);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // POST: /PaymentIssue/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        //
        // GET: /PaymentIssue/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Payment payment = db.Payments.Find(id, version);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        //
        // POST: /PaymentIssue/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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