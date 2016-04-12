namespace SEM.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Journal_ChangeAuthorID_Remove : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Journals");
            AlterColumn("dbo.Journals", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Journals", "Title", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Journals", "Id");
            DropColumn("dbo.Journals", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Journals", "AuthorId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Journals");
            AlterColumn("dbo.Journals", "Title", c => c.String());
            AlterColumn("dbo.Journals", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Journals", "Id");
        }
    }
}
