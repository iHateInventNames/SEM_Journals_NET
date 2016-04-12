namespace SEM.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JournalAddFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Journals", "File", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Journals", "File");
        }
    }
}
