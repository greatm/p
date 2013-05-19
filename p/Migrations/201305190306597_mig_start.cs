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

        }

        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.UserProfile");
        }
    }
}
