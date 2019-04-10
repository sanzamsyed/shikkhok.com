namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmailAsUnique : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.UserAccounts", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserAccounts", new[] { "Email" });
            AlterColumn("dbo.UserAccounts", "Email", c => c.String(nullable: false));
        }
    }
}
