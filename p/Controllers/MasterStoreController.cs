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
    public class MasterStoreController : Controller
    {
        private ContextP db = new ContextP();

        //
        // GET: /MasterStore/

        public ActionResult Index()
        {
            var lastVersions = from n in db.Stores
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
            //return View(db.Stores.ToList());
        }

        //
        // GET: /MasterStore/Details/5

        public ActionResult Details(int id = 0, int version = 0)
        {
            Store store = db.Stores.Find(id, version);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // GET: /MasterStore/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MasterStore/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Stores.Max(t => t.ID) + 1;
                }
                catch { }
                store.ID = iId;
                store.Version = 1;
                store.EntryDate = DateTime.Now;
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store);
        }

        //
        // GET: /MasterStore/Edit/5

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Store store = db.Stores.Find(id, version);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // POST: /MasterStore/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(store).State = EntityState.Modified;
                //Store newItem = new Store
                //{
                //    ID = store.ID,
                //    Version = store.Version + 1,
                //    //Timestamp = store.Timestamp,
                //    Name = store.Name,
                //    Description = store.Description,
                //    Remarks = store.Remarks
                //};
                Store newItem = store;
                newItem.Version = store.Version + 1;
                newItem.EntryDate = DateTime.Now;
                db.Stores.Add(newItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store);
        }

        //
        // GET: /MasterStore/Delete/5

        public ActionResult Delete(int id = 0, int version = 0)
        {
            Store store = db.Stores.Find(id, version);
            if (store == null)
            {
                return HttpNotFound();
            }
            return View(store);
        }

        //
        // POST: /MasterStore/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version)
        {
            Store store = db.Stores.Find(id, version);
            db.Stores.Remove(store);
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