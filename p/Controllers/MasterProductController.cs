﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p.Models;

namespace p.Controllers
{
    public class MasterProductController : Controller
    {
        private ContextP db = new ContextP();

        //
        // GET: /MasterProduct/

        public ActionResult Index()
        {
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
            //return View(db.Products.ToList());
        }

        //
        // GET: /MasterProduct/Details/5

        public ActionResult Details(int id = 0, int version = 0)
        {
            Product product = db.Products.Find(id, version);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /MasterProduct/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MasterProduct/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Products.Max(t => t.ID) + 1;
                }
                catch { }
                product.ID = iId;
                product.Version = 1;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /MasterProduct/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Product product = db.Products.Find(id, version);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /MasterProduct/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(product).State = EntityState.Modified;
                //try
                //{ db.SaveChanges(); }
                //catch (DBConcurrencyException)
                //{
                //    if (ModelState.IsValid)
                //    {
                //        //db.Products.Add(product);
                //        db.SaveChanges();
                //        return RedirectToAction("Index");
                //    }
                //}
                Product newProduct = new Product
                {
                    ID = product.ID,
                    Version = product.Version + 1,
                    //Timestamp = product.Timestamp,
                    Name = product.Name,
                    Category = product.Category,
                    Description = product.Description,
                    UoM = product.UoM,
                    RoL = product.RoL,
                    RoQ = product.RoQ,
                    LastPurchaseRate = product.LastPurchaseRate,
                    Color = product.Color,
                    Image = product.Image,
                    Remarks = product.Remarks
                };
                db.Products.Add(newProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /MasterProduct/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Product product = db.Products.Find(id, version);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /MasterProduct/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            Product product = db.Products.Find(id, version);
            db.Products.Remove(product);
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