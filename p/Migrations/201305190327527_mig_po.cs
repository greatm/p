namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_po : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.POItems", "PurchaseOrder_ID", "dbo.PurchaseOrders");
            DropForeignKey("dbo.POItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.PurchaseOrders", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors");
            DropTable("dbo.POItems");
            DropTable("dbo.PurchaseOrders");
        }
    }
}
