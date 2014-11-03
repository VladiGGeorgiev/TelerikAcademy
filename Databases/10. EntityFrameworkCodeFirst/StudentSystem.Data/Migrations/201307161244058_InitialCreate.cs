namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Homework",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        TimeSent = c.DateTime(nullable: false),
                        Course_Id = c.Int(),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.CourseStudents",
                c => new
                    {
                        Course_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course_Id, t.Student_Id })
                .ForeignKey("dbo.Courses", t => t.Course_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Course_Id)
                .Index(t => t.Student_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CourseStudents", new[] { "Student_Id" });
            DropIndex("dbo.CourseStudents", new[] { "Course_Id" });
            DropIndex("dbo.Homework", new[] { "Student_Id" });
            DropIndex("dbo.Homework", new[] { "Course_Id" });
            DropForeignKey("dbo.CourseStudents", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Homework", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Homework", "Course_Id", "dbo.Courses");
            DropTable("dbo.CourseStudents");
            DropTable("dbo.Homework");
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
        }
    }
}
