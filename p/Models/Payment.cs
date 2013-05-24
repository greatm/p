using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class Payment : VersionTable
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public GRN GRN { get; set; }
        public int GRNId { get; set; }
        public string ChequeNumber { get; set; }
        public string Bank { get; set; }
        public decimal Amount { get; set; }
    }
}