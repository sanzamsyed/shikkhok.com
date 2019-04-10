namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StilLTryingToFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserAccounts", new[] { "Username" });
            AlterColumn("dbo.UserAccounts", "FullName", c => c.String());
            AlterColumn("dbo.UserAccounts", "Username", c => c.String(maxLength: 450));
            CreateIndex("dbo.UserAccounts", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserAccounts", new[] { "Username" });
            AlterColumn("dbo.UserAccounts", "Username", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.UserAccounts", "FullName", c => c.String(nullable: false));
            CreateIndex("dbo.UserAccounts", "Username", unique: true);
        }
    }
}
