using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DbSet<Payment> Payments { get; set; }
    }
    public class VersionTable
    {
        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        //[Timestamp]
        //public Byte[] Timestamp { get; set; }
        public string Remarks { get; set; }
    }
    public static class Seeder
    {
        public static void Seed(ContextP context)
        {
            context.whatsnews.AddOrUpdate(
                p => p.WorkTime,

                   //new whatsnew { WorkTime = new DateTime(2013, 5, 24, 15, 00, 0), Work = "create purchase - contract " },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 24, 15, 00, 0), Work = "create purchase - contract " },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 24, 14, 00, 0), Work = "send contact email" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 23, 18, 00, 0), Work = "master product version add" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 23, 17, 00, 0), Work = "add message support" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 23, 16, 00, 0), Work = "master vendor edit – key error" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 23, 15, 00, 0), Work = "master vendor index – fit in page" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 23, 14, 00, 0), Work = "footer starts after menu" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 23, 10, 00, 0), Work = "add master store" },
                   new whatsnew { WorkTime = new DateTime(2013, 5, 22, 18, 00, 0), Work = "left menu - select previous item" },
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