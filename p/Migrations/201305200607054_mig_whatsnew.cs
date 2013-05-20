namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_whatsnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.whatsnews",
                c => new
                    {
                        WorkTime = c.DateTime(nullable: false),
                        Work = c.String(),
                    })
                .PrimaryKey(t => t.WorkTime);

        }

        public override void Down()
        {
            DropTable("dbo.whatsnews");
        }
    }
}
