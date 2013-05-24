using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class GRN : VersionTable
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public PurchaseOrder PO { get; set; }
        public int POID { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorID { get; set; }
        public string VendorInvoice { get; set; }
        public IEnumerable<GRNitem> PurchaseItems { get; set; }

        public IEnumerable<Vendor> Vendors { get; set; }
    }
}