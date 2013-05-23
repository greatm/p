using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class Store
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
        public string Description { get; set; }
        public string Remarks { get; set; }
    }
}