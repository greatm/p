using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p.Models;
using Rotativa;

namespace p.Controllers
{
    public class PurchaseContractController : Controller
    {
        #region var
        private ContextP db = new ContextP();
        #endregion

        #region action

        public ActionResult Index()
        {
            var lastVersions = from n in db.Contracts
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            return View(lastVersions);
        }
        IEnumerable<VersionTable> GetLastVersions(IEnumerable<VersionTable> tableToRead)
        {
            return from n in tableToRead
                   group n by n.ID into g
                   select g.OrderByDescending(t => t.Version).FirstOrDefault();
        }

        public ActionResult Details(int id = 0, int version = 0)
        {
            Contract contract = db.Contracts.Find(id, version);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        public ActionResult Create()
        {
            Contract newContract = new Contract { StartDate = DateTime.Today, EndDate = DateTime.Today.AddYears(1), ContractItems = new List<ContractItem>() };
            ContractItem contractItem = null;
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            CreateProductsList();
            foreach (Product prd in lastVersions)
            {
                //if (prd.RoL > 5)
                //{
                //contractItem = new ContractItem { Product = prd, ProductID = prd.ID, Rate = prd.LastPurchaseRate, Qty = prd.RoQ, Amount = prd.LastPurchaseRate * prd.RoQ };
                contractItem = new ContractItem { Product = prd, ProductID = prd.ID, Rate = prd.LastPurchaseRate, Qty = prd.RoQ, Amount = prd.LastPurchaseRate * prd.RoQ };
                //CreateProductsList(contractItem);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contract contract)
        {
            if (ModelState.IsValid)
            {
                int iId = 1;
                try
                {
                    iId = db.Contracts.Max(t => t.ID) + 1;
                }
                catch { }
                contract.ID = iId;
                contract.Version = 1;
                contract.EntryDate = DateTime.Now;
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

        public ActionResult Edit(int id = 0, int version = 0)
        {
            Contract contract = db.Contracts.Find(id, version);
            if (contract == null)
            {
                return HttpNotFound();
            }

            CreateVendorsList(contract);
            CreateProductsList();

            db.Entry(contract).Collection(t => t.ContractItems).Load();
            //foreach (ContractItem citem in contract.ContractItems)
            //{
            //citem.Products = CreateProductsList();
            //CreateProductsList(citem);
            //}

            return View(contract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contract contract)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contract).State = EntityState.Modified;
                //Contract newItem = new Contract
                //{
                //    ID = product.ID,
                //    Version = product.Version + 1,
                //    Timestamp = product.Timestamp,
                //    Name = product.Name,
                //    Category = product.Category,
                //    Description = product.Description,
                //    UoM = product.UoM,
                //    RoL = product.RoL,
                //    RoQ = product.RoQ,
                //    LastPurchaseRate = product.LastPurchaseRate,
                //    Color = product.Color,
                //    Image = product.Image,
                //    Remarks = product.Remarks
                //};
                Contract newItem = contract; //new Contract();
                //newItem = contract;
                newItem.Version = contract.Version + 1;
                newItem.EntryDate = DateTime.Now;

                db.Contracts.Add(newItem);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contract);
        }

        //
        // GET: /PurchaseContract/Delete/5

        public ActionResult Print(int id = 0, int version = 0)
        {
            return new ActionAsPdf("Edit", new { id = id, version = version }) { FileName = "contract.pdf" };
        }
        public ActionResult Delete(int id = 0, int version = 0)
        {
            Contract contract = db.Contracts.Find(id, version);
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
        public ActionResult DeleteConfirmed(int id, int version = 0)
        {
            Contract contract = db.Contracts.Find(id, version);
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
            var lastVersions = from n in db.Vendors
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            var vendors = db.Vendors;
            List<object> newList = new List<object>();
            foreach (var vendor in lastVersions)
                newList.Add(new
                {
                    Id = vendor.ID,
                    Name = vendor.Name + " : " + vendor.Person
                });
            this.ViewData["VendorID"] = new SelectList(newList, "Id", "Name", contract.VendorID);
        }
        //private void CreateProductsList(ContractItem contractItem)
        //{
        //    var lastVersions = from n in db.Products
        //                       group n by n.ID into g
        //                       select g.OrderByDescending(t => t.Version).FirstOrDefault();
        //    this.ViewData["ProductID"] = new SelectList(lastVersions, "Id", "Name", contractItem.ProductID);
        //}
        //private SelectList CreateProductsList()
        //{
        //    var lastVersions = from n in db.Products
        //                       group n by n.ID into g
        //                       select g.OrderByDescending(t => t.Version).FirstOrDefault();
        //    return new SelectList(lastVersions, "Id", "Name");

        //}
        private void CreateProductsList(ContractItem contractItem)
        {
            var lastVersions = from n in db.Products
                               group n by n.ID into g
                               select g.OrderByDescending(t => t.Version).FirstOrDefault();
            this.ViewData["Products"] = new SelectList(lastVersions, "Id", "Name", contractItem.ProductID);
        }
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