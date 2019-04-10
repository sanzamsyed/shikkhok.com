namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fresh : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        UserID = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                        CommentText = c.String(),
                    })
                .PrimaryKey(t => t.CommentID);
            
        }
    }
}
