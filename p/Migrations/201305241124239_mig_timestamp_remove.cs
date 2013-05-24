namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_timestamp_remove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vendors", "Timestamp");
            DropColumn("dbo.Products", "Timestamp");
            DropColumn("dbo.Contracts", "Timestamp");
            DropColumn("dbo.GRNs", "Timestamp");
            DropColumn("dbo.Payments", "Timestamp");
        }

        public override void Down()
        {
            AddColumn("dbo.Payments", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.GRNs", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Contracts", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Products", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Vendors", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
