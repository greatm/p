namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_store : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

            AddForeignKey("dbo.PurchaseOrders", "StoreID", "dbo.Stores", "ID", cascadeDelete: true);
            CreateIndex("dbo.PurchaseOrders", "StoreID");
        }

        public override void Down()
        {
            DropIndex("dbo.PurchaseOrders", new[] { "StoreID" });
            DropForeignKey("dbo.PurchaseOrders", "StoreID", "dbo.Stores");
            DropTable("dbo.Stores");
        }
    }
}
