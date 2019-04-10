namespace KnowYourProfDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckingWhatIsActuallyWrongWithLoginAfterAddingTeacherTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Masters",
                c => new
                    {
                        MID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.String(),
                        Department = c.String(),
                        Course = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.MID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Masters");
        }
    }
}
