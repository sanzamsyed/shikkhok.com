namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Um : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        Username = c.String(),
                        TeacherName = c.String(),
                        ReviewDate = c.DateTime(nullable: false),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => t.ReviewID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reviews");
        }
    }
}
