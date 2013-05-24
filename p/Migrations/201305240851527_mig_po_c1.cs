namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_po_c1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GRNs", "PO_ID", c => c.Int());
            AddColumn("dbo.GRNs", "PO_Version", c => c.Int());
            AddColumn("dbo.GRNs", "Vendor_ID", c => c.Int());
            AddColumn("dbo.GRNs", "Vendor_Version", c => c.Int());
            AddForeignKey("dbo.GRNs", new[] { "PO_ID", "PO_Version" }, "dbo.PurchaseOrders", new[] { "ID", "Version" });
            AddForeignKey("dbo.GRNs", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors", new[] { "ID", "Version" });
            CreateIndex("dbo.GRNs", new[] { "PO_ID", "PO_Version" });
            CreateIndex("dbo.GRNs", new[] { "Vendor_ID", "Vendor_Version" });
        }

        public override void Down()
        {
            DropIndex("dbo.GRNs", new[] { "Vendor_ID", "Vendor_Version" });
            DropIndex("dbo.GRNs", new[] { "PO_ID", "PO_Version" });
            DropForeignKey("dbo.GRNs", new[] { "Vendor_ID", "Vendor_Version" }, "dbo.Vendors");
            DropForeignKey("dbo.GRNs", new[] { "PO_ID", "PO_Version" }, "dbo.PurchaseOrders");
            DropColumn("dbo.GRNs", "Vendor_Version");
            DropColumn("dbo.GRNs", "Vendor_ID");
            DropColumn("dbo.GRNs", "PO_Version");
            DropColumn("dbo.GRNs", "PO_ID");
        }
    }
}
