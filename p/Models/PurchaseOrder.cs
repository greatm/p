﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace p.Models
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
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