namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_vendor_annot2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "ID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "ID", c => c.Int(nullable: false, identity: true));
        }
    }
}
