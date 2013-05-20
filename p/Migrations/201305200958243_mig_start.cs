namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);

            CreateTable(
                "dbo.whatsnews",
                c => new
                    {
                        WorkTime = c.DateTime(nullable: false),
                        Work = c.String(),
                    })
                .PrimaryKey(t => t.WorkTime);

            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Version = c.Int(nullable: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Name = c.String(),
                        Person = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Mobile = c.String(),
                        Phone = c.String(),
                        eMail = c.String(),
                        WebSite = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version });

            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Name = c.String(nullable: false),
                        Category = c.String(),
                        Description = c.String(),
                        UoM = c.String(),
                        RoL = c.Int(nullable: false),
                        RoQ = c.Int(nullable: false),
                        LastPurchaseRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Color = c.String(),
                        Image = c.Binary(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        VendorID = c.Int(nullable: false),
                        Recurrence = c.String(),
                        Remarks = c.String(),
                        Vendor_ID = c.Int(),
                        Vendor_Version = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vendors", t => new { t.Vendor_ID, t.Vendor_Version })
                .Index(t => new { t.Vendor_ID, t.Vendor_Version });

            CreateTable(
                "dbo.ContractItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Contract_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Contracts", t => t.Contract_ID)
                .Index(t => t.ProductID)
                .Index(t => t.Contract_ID);

            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Date = c.DateTime(nullable: false),
                        VendorID = c.Int(nullable: false),
                        StoreID = c.Int(nullable: false),
                        Remarks = c.String(),
                        Vendor_ID = c.Int(),
                        Vendor_Version = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Vendors", t => new { t.Vendor_ID, t.Vendor_Version })
                .Index(t => new { t.Vendor_ID, t.Vendor_Version });

            CreateTable(
                "dbo.POItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ProductID = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseOrder_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseOrders", t => t.PurchaseOrder_ID)
                .Index(t => t.ProductID)
                .Index(t => t.PurchaseOrder_ID);

        }

        public override void Down()
        {
            DropIndex("dbo.POItems", new[] { "PurchaseOrder_ID" });
            DropIndex("dbo.POItems", new[] { "ProductID" });
            DropIndex("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" });
            DropIndex("dbo.ContractItems", new[] { "Contract_ID" });
            DropIndex("dbo.ContractItems", new[] { "ProductID" });
            DropIndex("dbo.Contracts", new[] { "Vendor_ID", "Vendor_Version" });
            DropForeignKey("dbo.POItems", "PurchaseOrder_ID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.POItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors");
            DropForeignKey("dbo.ContractItems", "Contract_ID", "dbo.Contracts");
            DropForeignKey("dbo.ContractItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Contracts", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors");
            DropTable("dbo.POItems");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.ContractItems");
            DropTable("dbo.Contracts");
            DropTable("dbo.Products");
            DropTable("dbo.Vendors");
            DropTable("dbo.whatsnews");
            DropTable("dbo.UserProfile");
        }
    }
}
