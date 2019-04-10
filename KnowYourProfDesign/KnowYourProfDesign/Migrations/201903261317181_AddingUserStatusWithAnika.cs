namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserStatusWithAnika : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAccounts", "UserStatus", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAccounts", "UserStatus");
        }
    }
}
