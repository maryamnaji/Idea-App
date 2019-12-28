namespace IdeaApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ideas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        SubmissionDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Submitter_Id = c.Int(),
                        Topic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Submitter_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Submitter_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DisplayName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        Point = c.Int(nullable: false),
                        Thumbnail = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Department_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ideas", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Topics", "Owner_Id", "dbo.Users");
            DropForeignKey("dbo.Ideas", "Submitter_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Department_Id", "dbo.Departments");
            DropIndex("dbo.Topics", new[] { "Owner_Id" });
            DropIndex("dbo.Users", new[] { "Department_Id" });
            DropIndex("dbo.Ideas", new[] { "Topic_Id" });
            DropIndex("dbo.Ideas", new[] { "Submitter_Id" });
            DropTable("dbo.Topics");
            DropTable("dbo.Users");
            DropTable("dbo.Ideas");
            DropTable("dbo.Departments");
        }
    }
}
