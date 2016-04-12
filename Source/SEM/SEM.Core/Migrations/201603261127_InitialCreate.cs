namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Journal",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        Title = c.String(),
                        Path = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t=>t.AuthorID, cascadeDelete:true)
                .Index(t => t.AuthorID)
                ;
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JournalID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Journal", t => t.JournalID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.JournalID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subscription", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subscription", "JournalID", "dbo.Journal");
            DropForeignKey("dbo.Journal", "AuthorID", "dbo.AspNetUsers");
            DropIndex("dbo.Subscription", new[] { "UserID" });
            DropIndex("dbo.Subscription", new[] { "JournalID" });
            DropIndex("dbo.Journal", new[] { "AuthorID" });
            DropTable("dbo.Subscription");
            DropTable("dbo.Journal");
        }
    }
}
