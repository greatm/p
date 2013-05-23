using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class Product
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

        [Display(Prompt = "any thing about this product")]
        public string Remarks { get; set; }

        public Product()
        {
            RoL = 10;
            RoQ = 20;
        }
    }
}