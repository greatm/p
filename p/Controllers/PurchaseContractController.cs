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
        #region var
        private ContextP db = new ContextP();
        #endregion

        #region action
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
            Contract newContract = new Contract { StartDate = DateTime.Today, EndDate = DateTime.Today.AddYears(1), ContractItems = new List<ContractItem>() };
            ContractItem contractItem = null;
            foreach (Product prd in db.Products)
            {
                //if (prd.RoL > 5)
                //{
                contractItem = new ContractItem { Product = prd, ProductID = prd.ID, Rate = prd.LastPurchaseRate, Qty = prd.RoQ, Amount = prd.LastPurchaseRate * prd.RoQ };
                CreateProductsList(contractItem);
                newContract.ContractItems.Add(contractItem);
                //}
            }
            if (newContract.ContractItems.Count < 1)
            {
                  contractItem = new ContractItem();
                  CreateProductsList(contractItem);
                  newContract.ContractItems.Add(contractItem);
            }
            CreateVendorsList(newContract);
            return View(newContract);
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

            CreateVendorsList(contract);
            foreach (ContractItem contractItem in contract.ContractItems) CreateProductsList(contractItem);
            return View(contract);
        }
        public ActionResult ContractItemRow()
        {
            CreateProductsList(new ContractItem());
            return PartialView();
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
        #endregion

        #region function
        private void CreateVendorsList(Contract contract)
        {
            var vendors = db.Vendors;
            List<object> newList = new List<object>();
            foreach (var vendor in vendors)
                newList.Add(new
                {
                    Id = vendor.ID,
                    Name = vendor.Name + " : " + vendor.Person
                });
            this.ViewData["VendorID"] = new SelectList(newList, "Id", "Name", contract.VendorID);
        }
        private void CreateProductsList(ContractItem contractItem)
        {
            this.ViewData["ProductID"] = new SelectList(db.Products, "Id", "Name", contractItem.ProductID);
        }
        #endregion
    }
}