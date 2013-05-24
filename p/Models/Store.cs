﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p.Models
{
    public class Store : VersionTable
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}