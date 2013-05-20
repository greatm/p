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
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<whatsnew> whatsnews { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    }
    public static class Seeder
    {
        public static void Seed(ContextP context)
        {
            context.whatsnews.AddOrUpdate(
                p => p.WorkTime,


                   new whatsnew { WorkTime = new DateTime(2013, 5, 20, 10, 10, 0), Work = "add logo" }
                );
        }
    }
}