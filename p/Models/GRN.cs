using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class GRN
    {
        [Key, Column(Order = 0)]
        [Display(AutoGenerateField = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int POID { get; set; }
        public int VendorID { get; set; }
        public string VendorInvoice { get; set; }
        public string Remarks { get; set; }
        public IEnumerable<GRNitem> PurchaseItems { get; set; }

        public IEnumerable<Vendor> Vendors { get; set; }
    }
}