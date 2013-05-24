namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_payment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        GRNId = c.Int(nullable: false),
                        ChequeNumber = c.String(),
                        Bank = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Remarks = c.String(),
                        GRN_ID = c.Int(),
                        GRN_Version = c.Int(),
                    })
                .PrimaryKey(t => new { t.ID, t.Version })
                .ForeignKey("dbo.GRNs", t => new { t.GRN_ID, t.GRN_Version })
                .Index(t => new { t.GRN_ID, t.GRN_Version });

        }

        public override void Down()
        {
            DropIndex("dbo.Payments", new[] { "GRN_ID", "GRN_Version" });
            DropForeignKey("dbo.Payments", new[] { "GRN_ID", "GRN_Version" }, "dbo.GRNs");
            DropTable("dbo.Payments");
        }
    }
}
