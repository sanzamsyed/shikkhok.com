namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingUserStatusOnlyToBeAddedLater : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAccounts", "UserStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "UserStatus", c => c.String(nullable: false));
        }
    }
}
