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
        public DbSet<Store> Stores { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<GRN> GRNs { get; set; }
    }
    public static class Seeder
    {
        public static void Seed(ContextP context)
        {
            context.whatsnews.AddOrUpdate(
                p => p.WorkTime,


                   //new whatsnew { WorkTime = new DateTime(2013, 5, 22, 18, 00, 0), Work = "create master – product" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 17, 00, 0), Work = "create master – product" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 16, 00, 0), Work = "footer area color – blue" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 15, 00, 0), Work = "body area color – yellow" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 14, 00, 0), Work = "menu area color – blue" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 13, 00, 0), Work = "logo area color – blue" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 12, 00, 0), Work = "add whats new in about" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 11, 00, 0), Work = "create master – vendor" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 10, 10, 0), Work = "add ajax support" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 21, 10, 10, 0), Work = "add favicon" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 20, 10, 10, 0), Work = "add logo" }
                );
        }
    }
}