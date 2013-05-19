using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class Contract
    {
        public int ID { get; set; }
        [Timestamp]
        public Byte[] Timestamp { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Vendor Vendor { get; set; }
        public int VendorID { get; set; }
        public string Recurrence { get; set; }
        public string Remarks { get; set; }

        public IList<ContractItem> ContractItems { get; set; }
    }
}