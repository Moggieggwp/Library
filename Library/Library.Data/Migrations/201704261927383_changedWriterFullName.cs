namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedWriterFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writer", "FullName", c => c.String());
            DropColumn("dbo.Writer", "FirstName");
            DropColumn("dbo.Writer", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writer", "LastName", c => c.String());
            AddColumn("dbo.Writer", "FirstName", c => c.String());
            DropColumn("dbo.Writer", "FullName");
        }
    }
}
