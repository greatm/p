﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class Vendor
    {
        [Key, Column(Order = 0)]
        [Display(AutoGenerateField = true)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Timestamp]
        public Byte[] Timestamp { get; set; }
        [Required]
        public string Name { get; set; }
        public string Person { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string eMail { get; set; }
        public string WebSite { get; set; }
        public string Remarks { get; set; }
    }
}