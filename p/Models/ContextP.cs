using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace p.Models
{
    public class ContextP : DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}