namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_grn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GRNs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Date = c.DateTime(nullable: false),
                        POID = c.Int(nullable: false),
                        VendorID = c.Int(nullable: false),
                        VendorInvoice = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.GRNs");
        }
    }
}
