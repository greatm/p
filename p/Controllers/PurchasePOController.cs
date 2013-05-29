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
    public class PurchasePOController : Controller
    {
        #region var
        private ContextP db = new ContextP();
        #endregion

        #region action

        public ActionResult Index()
        {
            var lastVersions = from n in db.PurchaseOrders
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions.ToList());
            //return View(db.PurchaseOrders.ToList());
        }

        public ActionResult Details(int id = 0, int version = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id, version);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        public ActionResult Create()
        {
            PurchaseOrder newPO = new PurchaseOrder { Date = DateTime.Today, POItems = new List<POItem>() };
            POItem poitem = null;
            CreateProductsList();
            foreach (Product prd in db.Products)
            {
                if (prd.RoL > 5)
                {
                    poitem = new POItem { Product = prd, ProductID = prd.ID, Rate = prd.LastPurchaseRate, Qty = prd.RoQ, Amount = prd.LastPurchaseRate * prd.RoQ };
                    //CreateProductsList(poitem);
                    newPO.POItems.Add(poitem);
                }
            }
            if (newPO.POItems.Count < 1)
            {
                newPO.POItems.Add(new POItem());
            }
            CreateVendorsList(newPO);
            CreateStoresList(newPO);
            return View(newPO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PurchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseOrders.Add(purchaseorder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            CreateVendorsList(purchaseorder);
            CreateProductsList();

            return View(purchaseorder);
        }

        public ActionResult Edit(int id = 0, int version = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id, version);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseOrder purchaseorder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseorder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseorder);
        }

        public ActionResult Delete(int id = 0, int version = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id, version);
            if (purchaseorder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseorder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            PurchaseOrder purchaseorder = db.PurchaseOrders.Find(id, version);
            db.PurchaseOrders.Remove(purchaseorder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region function
        private void CreateVendorsList(PurchaseOrder workPO)
        {
            var vendors =  from n in db.Vendors
                                     group n by n.ID into g
                                     select g.OrderByDescending(t => t.Version).FirstOrDefault();
            List<object> newList = new List<object>();
            foreach (var vendor in vendors)
                newList.Add(new
                {
                    Id = vendor.ID,
                    Name = vendor.Name + " : " + vendor.Person
                });
            this.ViewData["VendorID"] = new SelectList(newList, "Id", "Name", workPO.VendorID);

        }
        private void CreateStoresList(PurchaseOrder workPO)
        {
            this.ViewData["StoreID"] = new SelectList(db.Products, "Id", "Name", workPO.StoreID);
        }
        //private void CreateProductsList(POItem poitem)
        //{
        //    this.ViewData["ProductID"] = new SelectList(db.Products, "Id", "Name", poitem.ProductID);
        //}
        private void CreateProductsList()
        {
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            this.ViewData["Products"] = new SelectList(lastVersions, "Id", "Name");
        }
        #endregion
    }
}