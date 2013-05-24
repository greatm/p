using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class Product : VersionTable
    {
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        [Display(Name = "Unit of Measurement", Prompt = "Enter here")]
        public string UoM { get; set; }

        [Display(Name = "Re Order Level")]
        public int RoL { get; set; }

        [Display(Name = "Re Order Quantity")]
        public int RoQ { get; set; }
        public decimal LastPurchaseRate { get; set; }
        public string Color { get; set; }
        public byte[] Image { get; set; }

        public Product()
        {
            RoL = 10;
            RoQ = 20;
        }
    }
}