namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_entryDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Stores", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contracts", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseOrders", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.GRNs", "EntryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Payments", "EntryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Stores", "Timestamp");
            DropColumn("dbo.PurchaseOrders", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.PurchaseOrders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Stores", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            DropColumn("dbo.Payments", "EntryDate");
            DropColumn("dbo.GRNs", "EntryDate");
            DropColumn("dbo.PurchaseOrders", "EntryDate");
            DropColumn("dbo.Contracts", "EntryDate");
            DropColumn("dbo.Stores", "EntryDate");
            DropColumn("dbo.Products", "EntryDate");
            DropColumn("dbo.Vendors", "EntryDate");
        }
    }
}
