namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "Username", c => c.String(nullable: false, maxLength: 450));
            CreateIndex("dbo.UserAccounts", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserAccounts", new[] { "Username" });
            AlterColumn("dbo.UserAccounts", "Username", c => c.String(nullable: false));
        }
    }
}
