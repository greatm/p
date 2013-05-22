namespace p.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class mig_contract_change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContractItems", "Contract_ID", "dbo.Contracts");
            DropIndex("dbo.ContractItems", new[] { "Contract_ID" });
            AddColumn("dbo.Contracts", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.ContractItems", "Contract_Version", c => c.Int());
            AlterColumn("dbo.Contracts", "ID", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Contracts", new[] { "ID" });
            AddPrimaryKey("dbo.Contracts", new[] { "ID", "Version" });
            AddForeignKey("dbo.ContractItems", new[] { "Contract_ID", "Contract_Version" }, "dbo.Contracts", new[] { "ID", "Version" });
            CreateIndex("dbo.ContractItems", new[] { "Contract_ID", "Contract_Version" });
        }

        public override void Down()
        {
            DropIndex("dbo.ContractItems", new[] { "Contract_ID", "Contract_Version" });
            DropForeignKey("dbo.ContractItems", new[] { "Contract_ID", "Contract_Version" }, "dbo.Contracts");
            DropPrimaryKey("dbo.Contracts", new[] { "ID", "Version" });
            AddPrimaryKey("dbo.Contracts", "ID");
            AlterColumn("dbo.Contracts", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ContractItems", "Contract_Version");
            DropColumn("dbo.Contracts", "Version");
            CreateIndex("dbo.ContractItems", "Contract_ID");
            AddForeignKey("dbo.ContractItems", "Contract_ID", "dbo.Contracts", "ID");
        }
    }
}
