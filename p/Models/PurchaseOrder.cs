using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class PurchaseOrder
    {
        [Key, Column(Order = 0)]
        //[Display(AutoGenerateField = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorID { get; set; }
        public Store Store { get; set; }
        public int StoreID { get; set; }
        public string Remarks { get; set; }
        public IList<POItem> POItems { get; set; }
    }
}