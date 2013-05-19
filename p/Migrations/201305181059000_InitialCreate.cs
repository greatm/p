namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        ID = c.Int(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendors");
        }
    }
}
