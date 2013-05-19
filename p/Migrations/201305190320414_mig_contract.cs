namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_contract : DbMigration
    {
        public override void Up()
        {
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

        }

        public override void Down()
        {
            DropIndex("dbo.ContractItems", new[] { "Contract_ID" });
            DropIndex("dbo.ContractItems", new[] { "ProductID" });
            DropIndex("dbo.Contracts", new[] { "Vendor_ID", "Vendor_Version" });
            DropForeignKey("dbo.ContractItems", "Contract_ID", "dbo.Contracts");
            DropForeignKey("dbo.ContractItems", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Contracts", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors");
            DropTable("dbo.ContractItems");
            DropTable("dbo.Contracts");
        }
    }
}
