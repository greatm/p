using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace p.Models
{
    public class POItem
    {
        public int ID { get; set; }
        [Timestamp]
        public Byte[] Timestamp { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int Qty { get; set; }
        public Decimal Rate { get; set; }
        public Decimal Amount { get; set; }
    }
}