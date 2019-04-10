namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContactUsName : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        ContactEmail = c.String(),
                        ContactSubject = c.String(),
                        ContactText = c.String(),
                    })
                .PrimaryKey(t => t.ContactID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUs");
        }
    }
}
